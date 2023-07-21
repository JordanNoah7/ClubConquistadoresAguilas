using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class ConsejeroController : Controller
{
    private readonly IAttendanceService _attendanceService;
    private readonly IClassService _classService;
    private readonly IPersonService _personService;
    private readonly IPositionService _positionService;
    private readonly IRoleService _roleService;
    private readonly IUnitService _unitService;
    private byte[] concurrency = new byte[8];

    public ConsejeroController(IPersonService personService, IClassService classService,
        IPositionService positionService,
        IRoleService roleService,
        IUnitService unitService, IAttendanceService attendanceService)
    {
        _personService = personService;
        _classService = classService;
        _positionService = positionService;
        _roleService = roleService;
        _unitService = unitService;
        _attendanceService = attendanceService;
    }

    // GET: ConsejeroController
    public ActionResult Index()
    {
        return View();
    }

    // GET: ConsejeroController/TomarLista
    public async Task<ActionResult> TomarLista()
    {
        var vmPathfinders = new List<VmPerson>();
        var person =
            await _personService.GetPersonClassById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        var pathfinders =
            await _personService.GetPathfindersByUnit(person.PositionPersonUnits.FirstOrDefault().Unit.Id);
        foreach (var pathfinder in pathfinders.ToList())
            vmPathfinders.Add(new VmPerson
            {
                Id = pathfinder.Id,
                FirstName = pathfinder.FirstName,
                FullSurname = pathfinder.FathersSurname + " " + pathfinder.MothersSurname,
                Total = pathfinder.Total
            });

        var vmPerson = new VmPerson
        {
            Unit = person.PositionPersonUnits.FirstOrDefault().Unit.Name,
            PersonList = vmPathfinders
        };
        return View(vmPerson);
    }

    // GET: ConsejeroController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmCounselors = new List<VmPerson>();
        var counselors = await _personService.GetCounselors();
        foreach (var item in counselors.ToList())
            vmCounselors.Add(new VmPerson
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name,
                Unit = item.PositionPersonUnits.FirstOrDefault().Unit.Name
            });

        var vmPerson = new VmPerson
        {
            PersonList = vmCounselors
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

            return RedirectToAction("Details", "Consejero");
        }
        catch
        {
            return RedirectToAction("Details", "Consejero");
        }
    }

    // GET: ConsejeroController/Edit/5
    public async Task<ActionResult> Edit(int nro)
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
        concurrency = new byte[8];
        Array.Copy(person.ConcurrencyPerson, concurrency, 8);
        HttpContext.Session.Set("Concurrency", person.ConcurrencyPerson);
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

    // POST: ConsejeroController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(int id, string Dni, string FirstName, string FatherSurname,
        string MotherSurname,
        DateTime Birthday, string Sex, int Phone, string Email, string Address, int Class, int Unit,
        int Position, int Role, string Username, string Password, string Attorney = null)
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
                PersonId = Convert.ToInt32(Attorney),
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
                }
            };
            Array.Copy(HttpContext.Session.Get("Concurrency"), person.ConcurrencyPerson, 8);
            if (await _personService.Update(person))
                return RedirectToAction("Details", "Consejero");
            return RedirectToAction("Details", "Consejero");
        }
        catch
        {
            return RedirectToAction("Details", "Consejero");
        }
    }

    // GET: ConsejeroController/Delete/5
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

    // POST: ConsejeroController/Delete/5
    [HttpPost]
    public async Task<ActionResult> Delete(int id, int nro)
    {
        try
        {
            await _personService.DeletePerson(nro);
            return RedirectToAction("Details", "Consejero");
        }
        catch
        {
            return RedirectToAction("Details", "Consejero");
        }
    }

    public async Task<ActionResult> Asistencia(int nro)
    {
        var person = await _personService.GetPersonClassById(nro);
        var vmPerson = new VmPerson
        {
            Id = person.Id,
            FirstName = person.FirstName,
            FathersSurname = person.FathersSurname,
            MothersSurname = person.MothersSurname
        };
        return View(vmPerson);
    }

    [HttpPost]
    public async Task<ActionResult> Asistencia(int id, int frecuency, int devotion, int monthly, int discipline,
        int year, int requeriments)
    {
        var attendance = new Attendance
        {
            PersonId = id,
            Frecuency = Convert.ToByte(frecuency),
            Devotion = Convert.ToByte(devotion),
            Monthly = Convert.ToByte(monthly),
            Discipline = Convert.ToByte(discipline),
            Year = Convert.ToByte(year),
            Requeriments = Convert.ToByte(requeriments)
        };
        await _attendanceService.Insert(attendance);
        return RedirectToAction("TomarLista", "Consejero");
    }

    // GET: ConsejeroController/Lista de conquistadores por unidad
    public async Task<ActionResult> EditClass(int nro)
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
        concurrency = new byte[8];
        Array.Copy(person.ConcurrencyPerson, concurrency, 8);
        HttpContext.Session.Set("Concurrency", concurrency);
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

    [HttpPost]
    public async Task<ActionResult> EditClass(int id, string Dni, string FirstName, string FatherSurname,
        string MotherSurname,
        DateTime Birthday, string Sex, int Phone, string Email, string Address, int Class, int Unit,
        int Position, int Role, string Username, string Password, string Attorney = null)
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
                PersonId = Convert.ToInt32(Attorney),
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
                }
            };
            Array.Copy(HttpContext.Session.Get("Concurrency"), person.ConcurrencyPerson, 8);
            if (await _personService.Update(person))
                return RedirectToAction("AsignarClase", "Consejero");
            return RedirectToAction("AsignarClase", "Consejero");
        }
        catch
        {
            return RedirectToAction("AsignarClase", "Consejero");
        }
    }

    // GET: ConsejeroController/Asignar Clase a Conquistador
    public async Task<ActionResult> AsignarClase()
    {
        var vmPathfinders = new List<VmPerson>();
        var person =
            await _personService.GetPersonClassById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        var pathfinders = await _personService.GetMembersByUnit(person.PositionPersonUnits.FirstOrDefault().Unit.Id);
        foreach (var pathfinder in pathfinders.ToList())
            vmPathfinders.Add(new VmPerson
            {
                Id = pathfinder.Id,
                FirstName = pathfinder.FirstName,
                FullSurname = pathfinder.FathersSurname + " " + pathfinder.MothersSurname,
                Class = pathfinder.ClassPeople.FirstOrDefault().Class.Name
            });

        var vmPerson = new VmPerson
        {
            Unit = person.PositionPersonUnits.FirstOrDefault().Unit.Name,
            PersonList = vmPathfinders
        };
        return View(vmPerson);
    }
}