using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PadreController : Controller
    {
        // GET: PadreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PadreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
}
