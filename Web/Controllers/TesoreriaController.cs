using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class TesoreriaController : Controller
{
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
    public ActionResult Ahorro(int id)
    {
        return View();
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