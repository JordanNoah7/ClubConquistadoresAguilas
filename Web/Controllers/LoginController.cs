using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class LoginController : Controller
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Login()
    {
        ViewBag.ErrorMessage = "";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _userService.GetByUsername(username);
        if (user == null)
        {
            ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        if (user.Password.Equals(password)) return RedirectToAction("Index", "Home");

        ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
        return View();


        /*if (username.Equals("admin") && password.Equals("12345"))
        {
            ViewBag.ErrorMessage = "Credenciales validas";
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.ErrorMessage = "Credenciales invalidas";
            return RedirectToAction("Login", "Login");
        }*/
    }
}