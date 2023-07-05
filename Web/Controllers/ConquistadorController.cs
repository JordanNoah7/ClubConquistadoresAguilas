using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ConquistadorController : Controller
{
    // GET: ConquistadorController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ConquistadorController/Details/5
    public ActionResult Details(int id)
    {
        return View();
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