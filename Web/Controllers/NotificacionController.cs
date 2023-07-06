using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class NotificacionController : Controller
{
    // GET: NotificacionController
    public ActionResult Index()
    {
        return View();
    }

    // GET: NotificacionController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: NotificacionController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: NotificacionController/Create
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

    // GET: NotificacionController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: NotificacionController/Edit/5
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

    // GET: NotificacionController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: NotificacionController/Delete/5
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