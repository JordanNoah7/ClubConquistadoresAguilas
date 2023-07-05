using Application.IService;
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
            var classId = person.ClassPeople.FirstOrDefault().ClassId;
            Console.WriteLine(classId.ToString());
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
        return View();
    }
}