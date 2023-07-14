using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class PadreController : Controller
{
    private readonly IPersonService _personService;

    public PadreController(IPersonService personService)
    {
        _personService = personService;
    }
    
    // GET: PadreController
    public ActionResult Index()
    {
        return View();
    }

    // GET: PadreController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmParents = new List<VmPerson>();
        var parents = await _personService.GetParents();
        foreach (var item in parents.ToList())
        {
            vmParents.Add(new VmPerson()
            {
                Id = item.Id,
                Dni = item.Dni,
                FirstName = item.FirstName,
                FathersSurname = item.FathersSurname,
                MothersSurname = item.MothersSurname,
                Phone = item.Phone
            });
        }

        var vmPerson = new VmPerson()
        {
            PersonList = vmParents
        };
        
        return View(vmPerson);
    }

    // GET: PadreController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PadreController/Create
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

    // GET: PadreController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: PadreController/Edit/5
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

    // GET: PadreController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PadreController/Delete/5
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