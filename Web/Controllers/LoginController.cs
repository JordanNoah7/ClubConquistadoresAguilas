using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Web.Controllers;

public class LoginController : Controller
{
    private readonly IPersonService _personService;
    private readonly IUserService _userService;

    public LoginController(IUserService userService, IPersonService personService)
    {
        _userService = userService;
        _personService = personService;
    }

    public IActionResult Login()
    {
        ViewBag.ErrorMessage = "";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        User user = await _userService.GetByUsername(username);
        if (user == null)
        {
            ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        if (user.Password.Equals(password))
        {
            Person person = await _personService.Get(user.Id);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
        return View();
    }
}