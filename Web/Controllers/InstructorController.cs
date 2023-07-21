using System.Security.Claims;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Web.Models;

namespace Web.Controllers;

public class InstructorController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IClassService _classService;
    private readonly IPersonService _personService;
    private readonly IPositionService _positionService;
    private readonly IRoleService _roleService;
    private readonly ISpecialtyService _specialtyService;
    private readonly IUnitService _unitService;

    private byte[] concurrency = new byte[8];

    public InstructorController(IPersonService personService, IClassService classService,
        IPositionService positionService,
        IRoleService roleService,
        IUnitService unitService, ISpecialtyService specialtyService,
        ICategoryService categoryService)
    {
        _personService = personService;
        _classService = classService;
        _positionService = positionService;
        _roleService = roleService;
        _unitService = unitService;
        _specialtyService = specialtyService;
        _categoryService = categoryService;
    }

    // GET: InstructorController
    public ActionResult Index()
    {
        return View();
    }

    // GET: InstructorController/Details/5
    public async Task<ActionResult> Details()
    {
        var vmInstructors = new List<VmPerson>();
        var instructors = await _personService.GetInstructors();
        foreach (var item in instructors.ToList())
            vmInstructors.Add(new VmPerson
            {
                Id = item.Id,
                FirstName = item.FirstName,
                FullSurname = item.FathersSurname + " " + item.MothersSurname,
                Class = item.ClassPeople.FirstOrDefault().Class.Name
            });

        var vmPerson = new VmPerson
        {
            PersonList = vmInstructors
        };

        return View(vmPerson);
    }

    // GET: InstructorController/Create
    public async Task<ActionResult> Create()
    {
        var classes = await _classService.GetClasses();

        ViewBag.Classes = classes.Select(c => new
        {
            Value = c.Id,
            Text = c.Name
        }).ToList();

        return View();
    }

    // GET: InstructorController/Registrar_Notas
    public async Task<ActionResult> Registrar_Notas()
    {
        var list = new List<VmPerson>();
        var person =
            await _personService.GetPersonClassById(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        var pathfinders = await _personService.GetPathfindersByClass(person.ClassPeople.FirstOrDefault().Class.Id);

        foreach (var pathfinder in pathfinders.ToList())
            list.Add(new VmPerson
            {
                Id = pathfinder.Id,
                FirstName = pathfinder.FirstName,
                FullSurname = pathfinder.FathersSurname + " " + pathfinder.MothersSurname
            });

        var categories = await _categoryService.GetCategories();
        ViewBag.Categories = categories.Select(c => new
        {
            Value = c.Id,
            Text = c.Name
        }).ToList();

        var vmPerson = new VmPerson
        {
            Class = person.ClassPeople.FirstOrDefault().Class.Name,
            PersonList = list
        };

        return View(vmPerson);
    }

    public async Task<ActionResult> Registrar_nota(int nro, int category)
    {
        var specialties = await _specialtyService.GetSpecialties(category);
        ViewBag.Specialties = specialties.Select(s => new
        {
            Value = s.Id,
            Text = s.Name
        }).ToList();
        
        var person = await _personService.GetPersonClassById(nro);
        VmPerson vmPerson = new VmPerson()
        {
            Id = nro,
            Dni = person.Dni,
            FirstName = person.FirstName,
            FathersSurname = person.FathersSurname, 
            MothersSurname = person.MothersSurname
        };
        return View(vmPerson);
    }

    [HttpPost]
    public async Task<ActionResult> Registrar_nota(int id, int specialty, int note)
    {
        Console.WriteLine(id + " " + specialty + " " + note);
        return RedirectToAction("Registrar_Notas", "Instructor");
    }

    // POST: InstructorController/Create
    [HttpPost]
    public async Task<ActionResult> Create(string Dni, string FirstName, string FatherSurname, string MotherSurname,
        DateTime Birthday, string Sex, string Phone, string Email, string Address, string Class, string Role,
        string Username, string Password)
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
                User = new User
                {
                    UserName = Username,
                    Password = Password
                },
                ClubId = 1
            };

            await _personService.InsertInstructor(person);

            return RedirectToAction("Details", "Instructor");
        }
        catch
        {
            return RedirectToAction("Details", "Instructor");
        }
    }

    // GET: InstructorController/Edit/5
    public async Task<ActionResult> Edit(int nro)
    {
        var classes = await _classService.GetClasses();

        ViewBag.Classes = classes.Select(c => new
        {
            Value = c.Id,
            Text = c.Name
        }).ToList();

        var person = await _personService.GetInstructorById(nro);
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
        HttpContext.Session.Set("Concurrency", concurrency);
        vmPerson.ClassId = person.ClassPeople.FirstOrDefault().ClassId;
        vmPerson.User = new VmUser
        {
            UserName = person.User.UserName,
            Password = person.User.Password
        };

        return View(vmPerson);
    }

    // POST: InstructorController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(int id, string Dni, string FirstName, string FatherSurname,
        string MotherSurname,
        DateTime Birthday, string Sex, string Phone, string Email, string Address, string Class, string Role,
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
                Phone = Phone,
                Email = Email,
                Address = Address,
                ClubId = 1,
                ClassPeople = new List<ClassPerson>
                {
                    new()
                    {
                        ClassId = Convert.ToByte(Class)
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

            if (await _personService.UpdateInstructor(person))
                return RedirectToAction("Details", "Instructor");
            return RedirectToAction("Details", "Instructor");
        }
        catch
        {
            return RedirectToAction("Details", "Instructor");
        }
    }

    // GET: InstructorController/Delete/5
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
            return RedirectToAction("Details", "Instructor");
        }
        catch
        {
            return RedirectToAction("Details", "Instructor");
        }
    }
}