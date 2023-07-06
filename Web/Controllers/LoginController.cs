using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

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
        var user = await _userService.GetUserRolByUsername(username);
        if (user == null)
        {
            ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        if (user.Password.Equals(password))
        {
            var person = await _personService.GetPersonClassById(user.Id);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, person.FirstName),
                new(ClaimTypes.Surname, person.FathersSurname + " " + person.MothersSurname),
                new(ClaimTypes.Role, user.UserRols.FirstOrDefault().Rol.Name),
                new(ClaimTypes.Actor, person.ClassPeople.FirstOrDefault().ClassId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            switch (user.UserRols.FirstOrDefault().Rol.Id)
            {
                case 1:
                    return RedirectToAction("Index", "Conquistador");
                case 2:
                    return RedirectToAction("Index", "Consejero");
                case 3:
                    return RedirectToAction("Index", "Instructor");
                case 4:
                    return RedirectToAction("Index", "Home");
                case 5:
                    return RedirectToAction("Details", "Conquistador");
                case 6:
                    return RedirectToAction("Index", "Padre");
            }
        }

        ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
        return View();
    }
}