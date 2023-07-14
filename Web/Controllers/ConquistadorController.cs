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

    private object concurrency;

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
        var fathers = await _personService.GetFathers();

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

        ViewBag.Fathers = fathers.Select(f => new
        {
            Value = f.Id,
            Text = f.FirstName + " " + f.FathersSurname + " " + f.MothersSurname
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
            
            
            var person = new Person
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
                PersonId = Convert.ToInt32(Attorney),
                ClubId = 1
            };
            Console.WriteLine(person.PersonId);

            await _personService.Insert(person);

            return RedirectToAction("Details", "Conquistador");
        }
        catch
        {
            return RedirectToAction("Details", "Conquistador");
        }
    }

    public async Task<ActionResult> Edit(int nro)
    {
        var classes = await _classService.GetClasses();
        var positions = await _positionService.GetPositions();
        var roles = await _roleService.GetRoles();
        var units = await _unitService.GetUnits();
        var fathers = await _personService.GetFathers();

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

        ViewBag.Fathers = fathers.Select(f => new
        {
            Value = f.Id,
            Text = f.FirstName + " " + f.FathersSurname + " " + f.MothersSurname
        }).ToList();

        concurrency = null;

        var person = await _personService.GetPathfinderById(nro);
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
        vmPerson.PersonId = person.PersonId == null ? 0 : person.PersonId;
        concurrency = person.ConcurrencyPerson;
        vmPerson.ClassId = person.ClassPeople.FirstOrDefault().ClassId;
        vmPerson.UnitId = person.PositionPersonUnits.FirstOrDefault().UnitId;
        vmPerson.PositionId = person.PositionPersonUnits.FirstOrDefault().PositionId;
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

    // POST: ConquistadorController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(int id, int Dni, string FirstName, string FatherSurname, string MotherSurname,
        DateTime Birthday, string Sex, int Phone, string Email, string Address, int Class, int Unit,
        int Position, int Role, string Username, string Password, string Attorney = null)
    {
        try
        {
            Person person = new Person()
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
                PersonId = Convert.ToInt32(Attorney),
                    ClassPeople = new List<ClassPerson>()
                {
                    new ClassPerson()
                    {
                        ClassId = Convert.ToByte(Class)
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
                }
            };
            
            if(await _personService.Update(person))
            {
                return RedirectToAction("Details", "Conquistador");
            }
            else
            {
                return RedirectToAction("Details", "Conquistador");
            }
        }
        catch
        {
            return RedirectToAction("Details", "Conquistador");
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