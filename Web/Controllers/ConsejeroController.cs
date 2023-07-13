using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class ConsejeroController : Controller
{
    private readonly IPersonService _personService;

    public ConsejeroController(IPersonService personService)
    {
        _personService = personService;
    }
    
    // GET: ConsejeroController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ConsejeroController/TomarLista
    public ActionResult TomarLista()
    {
        return View();
    }

    // GET: ConsejeroController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var vmCounselors = new List<VmPerson>();
        var counselors = await _personService.GetCounselors();
        foreach (var item in counselors.ToList())
        {
            vmCounselors.Add(new VmPerson()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name,
                Unit = item.PositionPersonUnits.FirstOrDefault().Unit.Name
            });
        }
        
        var vmPerson = new VmPerson
        {
            PersonList = vmCounselors,
        };

        return View(vmPerson);
    }

    // GET: ConsejeroController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ConsejeroController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ConsejeroController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ConsejeroController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ConsejeroController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ConsejeroController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}