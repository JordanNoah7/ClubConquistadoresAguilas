using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class InstructorController : Controller
{
    private readonly IPersonService _personService;

    public InstructorController(IPersonService personService)
    {
        _personService = personService;
    }
    
    // GET: InstructorController
    public ActionResult Index()
    {
        return View();
    }

    // GET: InstructorController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmInstructors = new List<VmPerson>();
        var instructors = await _personService.GetInstructors();
        foreach (var item in instructors.ToList())
        {
            vmInstructors.Add(new VmPerson()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name
            });
        }

        var vmPerson = new VmPerson()
        {
            PersonList = vmInstructors
        };
        
        return View(vmPerson);
    }

    // GET: InstructorController/Create
    public ActionResult Create()
    {
        return View();
    }

    // GET: InstructorController/Registrar_Notas
    public ActionResult Registrar_Notas()
    {
        return View();
    }

    // POST: InstructorController/Create
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

    // GET: InstructorController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: InstructorController/Edit/5
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

    // GET: InstructorController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: InstructorController/Delete/5
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