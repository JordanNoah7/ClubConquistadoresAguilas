﻿using System.Globalization;
using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        var user = await _userService.GetUserRolByUsername(username);
        if (user == null)
        {
            ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        if (user.Password.Equals(password))
        {
            Person person = await _personService.GetPersonClassById(user.Id);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, person.FirstName),
                new(ClaimTypes.Surname, person.FathersSurname + " " + person.MothersSurname),
                new(ClaimTypes.Role, user.UserRols.FirstOrDefault().Rol.Name),
                new(ClaimTypes.Actor, person.ClassPeople.FirstOrDefault().Class.Name),
                new(ClaimTypes.Authentication, person.PositionPersonUnits.FirstOrDefault().Unit.Name),
                new(ClaimTypes.DateOfBirth, person.BirthDate.ToString("dd/MM/yyyy")),
                new(ClaimTypes.MobilePhone, person.Phone),
                new(ClaimTypes.Email, person.Email)
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
                    return RedirectToAction("Inicio", "Crud");
                case 2:
                    return RedirectToAction("Inicio", "Crud");
                case 3:
                    return RedirectToAction("Inicio", "Crud");
                case 4:
                    return RedirectToAction("Inicio", "Crud");
                case 5:
                    return RedirectToAction("Inicio", "Crud");
                case 6:
                    return RedirectToAction("Index", "Padre");
            }
        }

        ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos";
        return View();
    }

    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}