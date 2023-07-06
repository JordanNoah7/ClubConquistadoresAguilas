using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class ConquistadorController : Controller
{
    private readonly IClassService _classService;
    private readonly IPersonService _personService;
    private readonly IPositionService _positionService;
    private readonly IRoleService _roleService;
    private readonly IUnitService _unitService;

    public ConquistadorController(IPersonService personService, IClassService classService,
        IPositionService positionService,
        IRoleService roleService,
        IUnitService unitService)
    {
        _personService = personService;
        _classService = classService;
        _positionService = positionService;
        _roleService = roleService;
        _unitService = unitService;
    }

    // GET: ConquistadorController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ConquistadorController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmPathfinders = new List<VmPerson>();
        var pathfinders = await _personService.GetPathfinders();
        var enumerable = pathfinders.ToList();
        foreach (var item in enumerable)
            vmPathfinders.Add(new VmPerson
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name,
                Unit = item.PositionPersonUnits.FirstOrDefault().Unit.Name,
                Position = item.PositionPersonUnits.FirstOrDefault().Position.Name
            });
        var vmPerson = new VmPerson
        {
            PersonList = vmPathfinders
        };
        return View(vmPerson);
    }

    // GET: ConquistadorController/Create
    public async Task<ActionResult> Create()
    {
        var classes = await _classService.GetClasses();
        var positions = await _positionService.GetPositions();
        var roles = await _roleService.GetRoles();
        var units = await _unitService.GetUnits();

        ViewBag.Classes = classes.Select(c => new
        {
            Value = c.Id,
            Text = c.Name
        }).ToList();

        //ViewBag.Classes = new SelectList(classes.ToList(), "Id", "Nombre");
        ViewBag.Positions = positions.Select(p => new
        {
            Value = p.Id,
            Text = p.Name
        }).ToList();
        ViewBag.Roles = roles.Select(r => new
        {
            Value = r.Id,
            Text = r.Name
        }).ToList();
        ViewBag.Units = units.Select(u => new
        {
            Value = u.Id,
            Text = u.Name
        }).ToList();

        return View();
    }

    // POST: ConquistadorController/Create
    [HttpPost]
    public async Task<ActionResult> Create(string Dni, string FirstName, string FatherSurname, string MotherSurname,
        DateTime Birthday, string Sex, string Phone, string Email, string Address, string Class,
        string Unit, string Position, string Role, string Username, string Password, string Attorney = null)
    {
        try
        {
            Person person = new Person()
            {
                Dni = Convert.ToInt32(Dni),
                FirstName = FirstName,
                FathersSurname = FatherSurname,
                MothersSurname = MotherSurname,
                BirthDate = Convert.ToDateTime(Birthday),
                Gender = Sex,
                Phone = Phone,
                Email = Email,
                Address = Address,
                ClassPeople = new List<ClassPerson>()
                { new ClassPerson()
                    {
                        ClassId = Convert.ToByte(Class),
                    }
                },
                PositionPersonUnits = new List<PositionPersonUnit>()
                {
                    new PositionPersonUnit()
                    {
                        PositionId = Convert.ToByte(Position),
                        UnitId = Convert.ToByte(Unit)
                    }
                },
                User = new User()
                {
                    UserName = Username,
                    Password = Password,
                    UserRols = new List<UserRol>()
                    {
                        new UserRol()
                        {
                            RolId = Convert.ToByte(Role)
                        }
                    }
                },
                PersonId = Convert.ToInt32(Attorney)
            };

            await _personService.Insert(person);
            
            return RedirectToAction("Details", "Conquistador");
        }
        catch
        {
            return RedirectToAction("Details", "Conquistador");
        }
    }

    // GET: ConquistadorController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ConquistadorController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Details));
        }
        catch
        {
            return View();
        }
    }

    // GET: ConquistadorController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ConquistadorController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Details));
        }
        catch
        {
            return View();
        }
    }
}