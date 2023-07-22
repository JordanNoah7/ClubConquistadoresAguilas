using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Web.Controllers;

public class TesoreriaController : Controller
{
    private readonly IPersonService _personService;
    private readonly IAttendanceService _attendanceService;

    public TesoreriaController(IPersonService personService, IAttendanceService attendanceService)
    {
        _personService = personService;
        _attendanceService = attendanceService;
    }
    
    // GET: TesoreriaController
    public ActionResult Index()
    {
        return View();
    }

    // GET: TesoreriaController/Inscripcion
    public ActionResult Inscripcion(int id)
    {
        return View();
    }

    // GET: TesoreriaController/Ahorro
    public async Task<ActionResult> Ahorro(int id)
    {
        var pathfinders = await _personService.GetPathfindersWithoutFee();
        ViewBag.Pathfinders = pathfinders.Select(p => new
        {
            Value = p.Id,
            Text = p.FirstName + " " + p.FathersSurname + " " + p.MothersSurname
        }).ToList();
        return View();
    }
    
    [HttpPost]
    public async Task<ActionResult> Ahorro(int pathfinder, string import)
    {
        Person person = new Person()
        {
            Id = pathfinder,
            TotalSavings = Convert.ToDecimal(import)
        };
        await _attendanceService.InsertFee(person);
        return RedirectToAction("Inicio", "Crud");
    }

    // GET: TesoreriaController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: TesoreriaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: TesoreriaController/Create
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

    // GET: TesoreriaController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: TesoreriaController/Edit/5
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

    // GET: TesoreriaController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: TesoreriaController/Delete/5
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