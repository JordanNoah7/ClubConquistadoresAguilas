using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

/*  [Authorize]*/
public class CrudController : Controller
{
    private readonly IPersonService _personService;

    public CrudController(IPersonService personService)
    {
        _personService = personService;
    }

    // GET: CrudController
    public async Task<ActionResult> Inicio()
    {
        var person =
            await _personService.GetPersonClassById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        var vmPerson = new VmPerson
        {
            BirthDate = person.BirthDate.ToString("yyyy-MM-dd"),
            Phone = person.Phone,
            Email = person.Email,
            Class = person.ClassPeople.FirstOrDefault().Class.Name,
            Unit = person.PositionPersonUnits.FirstOrDefault().Unit.Name,
            TotalPoints = person.TotalPoints,
            TotalSavings = person.TotalSavings
        };
        return View(vmPerson);
    }

    /*public ActionResult CrudConquistador()
    {
        return View();
    }

    public ActionResult CrudConsejero()
    {
        return View();
    }

    public ActionResult CrudInstructor()
    {
        return View();
    }

    public ActionResult Actividades()
    {
        return View();
    }

    // GET: CrudController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: CrudController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CrudController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Inicio));
        }
        catch
        {
            return View();
        }
    }

    // GET: CrudController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CrudController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Inicio));
        }
        catch
        {
            return View();
        }
    }

    // GET: CrudController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CrudController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Inicio));
        }
        catch
        {
            return View();
        }
    }*/
}