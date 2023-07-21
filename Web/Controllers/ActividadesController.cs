using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class ActividadesController : Controller
{
    private readonly IActivityService _activityService;
    private readonly IPersonService _personService;

    private readonly byte[] concurrency = new byte[8];

    public ActividadesController(IActivityService activityService, IPersonService personService)
    {
        _activityService = activityService;
        _personService = personService;
    }

    // GET: ActividadesController
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<ActionResult> Participantes(int nro)
    {
        var vmActivities = new VmActivity();

        var participants = await _activityService.GetParticipants(nro);
        var participantList = new List<VmPerson>();

        var noParticipants = await _activityService.GetNoParticipants(nro);
        var noParticipantList = new List<VmPerson>();

        foreach (var item in participants.ToList())
            participantList.Add(new VmPerson
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FathersSurname = item.FathersSurname,
                MothersSurname = item.MothersSurname
            });

        foreach (var item in noParticipants.ToList())
            noParticipantList.Add(new VmPerson
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FathersSurname = item.FathersSurname,
                MothersSurname = item.MothersSurname
            });

        vmActivities.Id = nro;
        vmActivities.Participants = participantList;
        vmActivities.NoParticipants = noParticipantList;

        return View(vmActivities);
    }

    [HttpPost]
    public async Task<ActionResult> AddParticipants(int nro, int id)
    {
        await _activityService.InsertParticipant(nro, id);
        return RedirectToAction("Participantes", "Actividades", new { nro });
    }

    [HttpPost]
    public async Task<ActionResult> DeleteParticipants(int nro, int id)
    {
        await _activityService.DeleteParticipant(nro, id);
        return RedirectToAction("Participantes", "Actividades", new { nro });
    }

    // GET: ActividadesController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmActivities = new List<VmActivity>();

        var activities = await _activityService.GetActivities();

        var vmActivity = new VmActivity();

        if (activities != null)
        {
            foreach (var item in activities.ToList())
                vmActivities.Add(new VmActivity
                {
                    Id = item.Id,
                    Name = item.Name,
                    StartDate = item.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = item.EndDate.ToString("yyyy-MM-dd"),
                    Manager = new VmPerson
                    {
                        Id = item.Manager.Id,
                        FullSurname = item.Manager.FirstName + " " +
                                      item.Manager.FathersSurname + " " +
                                      item.Manager.MothersSurname
                    },
                    Location = item.Location
                });
            vmActivity.Activities = vmActivities;
        }
        else
        {
            vmActivity.Activities = null;
        }

        return View(vmActivity);
    }

    // GET: ActividadesController/Create
    public async Task<ActionResult> Create()
    {
        var managers = await _personService.GetManagers();
        ViewBag.Managers = managers.Select(m => new
        {
            Value = m.Id,
            Text = m.FirstName + " " + m.FathersSurname + " " + m.MothersSurname
        }).ToList();
        return View();
    }

    // POST: ActividadesController/Create
    [HttpPost]
    public async Task<ActionResult> Create(string name, DateTime startDate, DateTime endDate, string location,
        string description, string requirements, string manager)
    {
        try
        {
            var activity = new Activity
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Location = location,
                Description = description,
                Requirements = requirements,
                Manager = new Person
                {
                    Id = Convert.ToInt32(manager)
                }
            };
            await _activityService.Insert(activity);
            return RedirectToAction("Details", "Actividades");
        }
        catch
        {
            return RedirectToAction("Details", "Actividades");
        }
    }

    // GET: ActividadesController/Edit/5
    public async Task<ActionResult> Edit(int nro)
    {
        var managers = await _personService.GetManagers();
        ViewBag.Managers = managers.Select(m => new
        {
            Value = m.Id,
            Text = m.FirstName + " " + m.FathersSurname + " " + m.MothersSurname
        }).ToList();

        var activity = await _activityService.GetActivitie(nro);

        var vmActivity = new VmActivity
        {
            Name = activity.Name,
            StartDate = activity.StartDate.ToString("yyyy-MM-dd"),
            EndDate = activity.EndDate.ToString("yyyy-MM-dd"),
            Location = activity.Location,
            Description = activity.Description,
            Requirements = activity.Requirements,
            Manager = new VmPerson
            {
                Id = activity.Manager.Id
            }
        };
        vmActivity.Id = nro;

        Array.Copy(activity.ConcurrencyActivity, concurrency, 8);
        HttpContext.Session.Set("Concurrency", activity.ConcurrencyActivity);

        return View(vmActivity);
    }

    // POST: ActividadesController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(int id, string name, DateTime startDate, DateTime endDate, string location,
        string description, string requirements, string manager)
    {
        try
        {
            var activity = new Activity
            {
                Id = id,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Location = location,
                Description = description,
                Requirements = requirements,
                Manager = new Person
                {
                    Id = Convert.ToInt32(manager)
                }
            };
            Array.Copy(HttpContext.Session.Get("Concurrency"), activity.ConcurrencyActivity, 8);

            if (await _activityService.UpdateActivity(activity))
                return RedirectToAction("Details", "Actividades");
            return RedirectToAction("Edit", "Actividades", new { id });
        }
        catch
        {
            return View();
        }
    }

    // GET: ActividadesController/Delete/5
    public async Task<ActionResult> Delete(int nro)
    {
        var activity = await _activityService.GetActivitie(nro);
        var vmActivity = new VmActivity
        {
            Id = nro,
            Name = activity.Name
        };
        return View(vmActivity);
    }

    // POST: InstructorController/Delete/5
    [HttpPost]
    public async Task<ActionResult> Delete(int nro, int id)
    {
        try
        {
            await _activityService.DeleteActivity(nro);
            return RedirectToAction("Details", "Actividades");
        }
        catch
        {
            return RedirectToAction("Details", "Actividades");
        }
    }
}