using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class ConquistadorController : Controller
{
    private readonly IPersonService _personService;

    public ConquistadorController(IPersonService personService)
    {
        _personService = personService;
    }

    // GET: ConquistadorController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ConquistadorController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmPathfinders = new List<VmPerson>();
        var pathfinders = await _personService.GetPathfinders();
        var enumerable = pathfinders.ToList();
        foreach (var it in enumerable) Console.WriteLine(it.Id.ToString());
        foreach (var item in enumerable)
            vmPathfinders.Add(new VmPerson
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name,
                Unit = item.PositionPersonUnits.FirstOrDefault().Unit.Name,
                Position = item.PositionPersonUnits.FirstOrDefault().Position.Name
            });
        var vmPerson = new VmPerson
        {
            PersonList = vmPathfinders
        };
        return View(vmPerson);
    }

    // GET: ConquistadorController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ConquistadorController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Details));
        }
        catch
        {
            return View();
        }
    }

    // GET: ConquistadorController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ConquistadorController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Details));
        }
        catch
        {
            return View();
        }
    }

    // GET: ConquistadorController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ConquistadorController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Details));
        }
        catch
        {
            return View();
        }
    }
}