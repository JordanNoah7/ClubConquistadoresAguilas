using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Log_in(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("12345"))
            {
                ViewBag.ErrorMessage = "Credenciales validas";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Credenciales invalidas";
                return RedirectToAction("Login", "Login");
            }
        }
    }
    
}
