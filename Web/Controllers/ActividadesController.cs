using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ActividadesController : Controller
    {
        // GET: ActividadesController
        public ActionResult Index()
        {
            return View();
        }

        //actividades - participantes
        public ActionResult Participantes()
        {
            return View();
        }

        // GET: ActividadesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActividadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadesController/Create
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

        // GET: ActividadesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActividadesController/Edit/5
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

        // GET: ActividadesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActividadesController/Delete/5
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
