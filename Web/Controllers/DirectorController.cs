using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DirectorController : Controller
    {
        public IActionResult Director()
        {
            return View();
        }

    }
    
}
