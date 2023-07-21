﻿using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class PadreController : Controller
{
    private readonly IPersonService _personService;
    private readonly IRoleService _roleService;

    private byte[] concurrency = new byte[8];

    public PadreController(IPersonService personService, IRoleService roleService)
    {
        _personService = personService;
        _roleService = roleService;
    }

    // GET: PadreController
    public async Task<ActionResult> Index()
    {
        var vmChildren = new List<VmPerson>();
        var children =
            await _personService.GetChildrenByFather(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        foreach (var item in children.ToList())
        {
            vmChildren.Add(new VmPerson()
            {
                Id = item.Id,
                Dni = item.Dni,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name,
                Unit = item.PositionPersonUnits.FirstOrDefault().Unit.Name
            });
        }

        VmPerson vmPerson = new VmPerson()
        {
            PersonList = vmChildren
        };
        return View(vmPerson);
    }

    // GET: PadreController/PerfilConquis--para mostrar perfil del hijo conquistador
    public async Task<ActionResult> PerfilHijoConquis(int nro)
    {
        Person person = await _personService.GetPersonClassById(nro);
        VmPerson vmPerson = new VmPerson()
        {
            Id = person.Id,
            FirstName = person.FirstName,
            FullSurname = person.FathersSurname + " " + person.MothersSurname,
            BirthDate = person.BirthDate.ToString("yyyy-MM-dd"),
            Phone = person.Phone,
            Email = person.Email,
            Class = person.ClassPeople.FirstOrDefault().Class.Name,
            Unit = person.PositionPersonUnits.FirstOrDefault().Unit.Name,
            TotalPoints = person.TotalPoints,
            TotalSavings = person.TotalSavings
        };
        return View(vmPerson);
    }

    // GET: PadreController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmParents = new List<VmPerson>();
        var parents = await _personService.GetParents();
        foreach (var item in parents.ToList())
            vmParents.Add(new VmPerson
            {
                Id = item.Id,
                Dni = item.Dni,
                FirstName = item.FirstName,
                FathersSurname = item.FathersSurname,
                MothersSurname = item.MothersSurname,
                Phone = item.Phone
            });

        var vmPerson = new VmPerson
        {
            PersonList = vmParents
        };

        return View(vmPerson);
    }

    // GET: PadreController/Create
    public async Task<ActionResult> Create()
    {
        var roles = await _roleService.GetRoles();
        ViewBag.Roles = roles.Select(r => new
        {
            Value = r.Id,
            Text = r.Name
        }).ToList();

        return View();
    }

    // POST: PadreController/Create
    [HttpPost]
    public async Task<ActionResult> Create(string Dni, string FirstName, string FatherSurname, string MotherSurname,
        DateTime Birthday, string Sex, string Phone, string Email, string Address, string Role, string Username,
        string Password)
    {
        try
        {
            var person = new Person
            {
                Dni = Dni,
                FirstName = FirstName,
                FathersSurname = FatherSurname,
                MothersSurname = MotherSurname,
                BirthDate = Convert.ToDateTime(Birthday),
                Gender = Sex,
                Phone = Phone,
                Email = Email,
                Address = Address,
                User = new User
                {
                    UserName = Username,
                    Password = Password,
                    UserRols = new List<UserRol>
                    {
                        new()
                        {
                            RolId = Convert.ToByte(Role)
                        }
                    }
                },
                ClubId = 1
            };

            await _personService.InsertParent(person);

            return RedirectToAction("Details", "Padre");
        }
        catch
        {
            return RedirectToAction("Details", "Padre");
        }
    }

    // GET: PadreController/Edit/5
    public async Task<ActionResult> Edit(int nro)
    {
        var roles = await _roleService.GetRoles();

        ViewBag.Roles = roles.Select(r => new
        {
            Value = r.Id,
            Text = r.Name
        }).ToList();

        concurrency = null;

        var person = await _personService.GetParentById(nro);
        var vmPerson = new VmPerson();
        vmPerson.Id = nro;
        vmPerson.Dni = person.Dni;
        vmPerson.FirstName = person.FirstName;
        vmPerson.FathersSurname = person.FathersSurname;
        vmPerson.MothersSurname = person.MothersSurname;
        vmPerson.BirthDate = person.BirthDate.ToString("yyyy-MM-dd");
        vmPerson.Gender = person.Gender;
        vmPerson.Phone = person.Phone;
        vmPerson.Email = person.Email;
        vmPerson.Address = person.Address;
        concurrency = new byte[8];
        Array.Copy(person.ConcurrencyPerson, concurrency, 8);
        HttpContext.Session.Set("concurrency", concurrency);
        vmPerson.User = new VmUser
        {
            UserName = person.User.UserName,
            Password = person.User.Password,
            Role = new VmRole
            {
                Id = person.User.UserRols.FirstOrDefault().RolId
            }
        };

        return View(vmPerson);
    }

    // POST: PadreController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(int id, string Dni, string FirstName, string FatherSurname,
        string MotherSurname, DateTime Birthday, string Sex, int Phone, string Email, string Address, int Role,
        string Username, string Password)
    {
        try
        {
            var person = new Person
            {
                Id = id,
                Dni = Dni,
                FirstName = FirstName,
                FathersSurname = FatherSurname,
                MothersSurname = MotherSurname,
                BirthDate = Birthday,
                Gender = Sex,
                Phone = Phone.ToString(),
                Email = Email,
                Address = Address,
                ClubId = 1,
                User = new User
                {
                    UserName = Username,
                    Password = Password,
                    UserRols = new List<UserRol>
                    {
                        new()
                        {
                            RolId = Convert.ToByte(Role)
                        }
                    }
                }
            };
            Array.Copy(HttpContext.Session.Get("concurrency"), person.ConcurrencyPerson, 8);
            if (await _personService.UpdateParent(person))
                return RedirectToAction("Details", "Padre");
            return RedirectToAction("Details", "Padre");
        }
        catch
        {
            return RedirectToAction("Details", "Padre");
        }
    }

    // GET: PadreController/Delete/5
    public async Task<ActionResult> Delete(int nro)
    {
        var person = await _personService.GetPersonById(nro);
        var vmPerson = new VmPerson
        {
            Id = nro,
            FirstName = person.FirstName,
            FathersSurname = person.FathersSurname,
            MothersSurname = person.MothersSurname
        };
        return View(vmPerson);
    }

    // POST: InstructorController/Delete/5
    [HttpPost]
    public async Task<ActionResult> Delete(int nro, int id)
    {
        try
        {
            await _personService.DeletePerson(nro);
            return RedirectToAction("Details", "Padre");
        }
        catch
        {
            return RedirectToAction("Details", "Padre");
        }
    }
}