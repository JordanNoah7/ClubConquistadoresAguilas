using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class ConsejeroController : Controller
{
    private readonly IPersonService _personService;
    private readonly IClassService _classService;
    private readonly IPositionService _positionService;
    private readonly IRoleService _roleService;
    private readonly IUnitService _unitService;

    public ConsejeroController(IPersonService personService, IClassService classService,
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
    
    // GET: ConsejeroController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ConsejeroController/TomarLista
    public ActionResult TomarLista()
    {
        return View();
    }
    // GET: ConsejeroController/Lista de conquistadores por unidad
    public ActionResult UnidadConsejero()
    {
        return View();
    }
    // GET: ConsejeroController/Asignar Clase a Conquistador
    public ActionResult AsignarClase()
    {
        return View();
    }

    // GET: ConsejeroController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmCounselors = new List<VmPerson>();
        var counselors = await _personService.GetCounselors();
        foreach (var item in counselors.ToList())
        {
            vmCounselors.Add(new VmPerson()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name,
                Unit = item.PositionPersonUnits.FirstOrDefault().Unit.Name
            });
        }
        
        var vmPerson = new VmPerson
        {
            PersonList = vmCounselors,
        };

        return View(vmPerson);
    }

    // GET: ConsejeroController/Create
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

    // POST: ConsejeroController/Create
    [HttpPost]
    public async Task<ActionResult> Create(string Dni, string FirstName, string FatherSurname, string MotherSurname,
        DateTime Birthday, string Sex, string Phone, string Email, string Address, string Class,
        string Unit, string Position, string Role, string Username, string Password)
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
                ClassPeople = new List<ClassPerson>
                {
                    new()
                    {
                        ClassId = Convert.ToByte(Class)
                    }
                },
                PositionPersonUnits = new List<PositionPersonUnit>
                {
                    new()
                    {
                        PositionId = Convert.ToByte(Position),
                        UnitId = Convert.ToByte(Unit)
                    }
                },
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

            await _personService.Insert(person);

            return RedirectToAction("Details", "Conquistador");
        }
        catch
        {
            return RedirectToAction("Details", "Conquistador");
        }
    }

    // GET: ConsejeroController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ConsejeroController/Edit/5
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

    // GET: ConsejeroController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ConsejeroController/Delete/5
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