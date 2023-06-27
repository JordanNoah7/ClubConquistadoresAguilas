using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CrudController : Controller
{
    // GET: CrudController
    public ActionResult Inicio()
    {
        return View();
    }

    public ActionResult CrudConquistador()
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

    // GET: CrudController/Details/5
    /*public ActionResult Details(int id)
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
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
<<<<<<< HEAD
=======

        public ActionResult CrudConquistador()
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
        }
>>>>>>> 5341ec88b4a9b921a93f05307ee80140179723ee
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
            return RedirectToAction(nameof(Index));
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
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }*/
}