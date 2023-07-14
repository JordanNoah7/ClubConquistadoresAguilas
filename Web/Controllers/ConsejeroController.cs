using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ConsejeroController : Controller
{
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
    // GET: ConsejeroController/Lista de conquistadores por unidad
    public ActionResult UnidadConsejero()
    {
        return View();
    }
    // GET: ConsejeroController/Asignar Clase a Conquistador
    public ActionResult AsignarClase()
    {
        return View();
    }

    // GET: ConsejeroController/Details/5
    public ActionResult Details(int id)
    {
        return View();
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