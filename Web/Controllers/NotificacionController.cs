﻿using System.Globalization;
using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class NotificacionController : Controller
{
    private readonly IPersonService _personService;

    public NotificacionController(IPersonService personService)
    {
        _personService = personService;
    }
    
    // GET: NotificacionController
    public async Task<ActionResult> Index()
    {
        Person person = await _personService.GetPersonClassById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        VmPerson vmPerson = new VmPerson()
        {
            Class = person.ClassPeople.FirstOrDefault().Class.Name,
            Unit = person.PositionPersonUnits.FirstOrDefault().Unit.Name,
        };
        return View(vmPerson);
    }

    // GET: NotificacionController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: NotificacionController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: NotificacionController/Create
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

    // GET: NotificacionController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: NotificacionController/Edit/5
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

    // GET: NotificacionController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: NotificacionController/Delete/5
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