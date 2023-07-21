using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepo;

    public PersonService(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public async Task<bool> InsertParent(Person model)
    {
        try
        {
            return await _personRepo.InsertParent(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> InsertInstructor(Person model)
    {
        try
        {
            return await _personRepo.InsertInstructor(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Person model)
    {
        try
        {
            return await _personRepo.Update(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateParent(Person model)
    {
        try
        {
            return await _personRepo.UpdateParent(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateInstructor(Person model)
    {
        try
        {
            return await _personRepo.UpdateInstructor(model);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> DeletePerson(int id)
    {
        try
        {
            return await _personRepo.DeletePerson(id);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<Person> GetParentById(int id)
    {
        try
        {
            return await _personRepo.GetParentById(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Person> GetPersonById(int id)
    {
        try
        {
            return await _personRepo.GetPersonById(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Person> GetInstructorById(int id)
    {
        try
        {
            return await _personRepo.GetInstructorById(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetCounselors()
    {
        try
        {
            return await _personRepo.GetCounselors();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetPathfindersByUnit(int id)
    {
        try
        {
            return await _personRepo.GetPathfindersByUnit(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetMembersByUnit(int id)
    {
        try
        {
            return await _personRepo.GetMembersByUnit(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetPathfindersByClass(int id)
    {
        try
        {
            return await _personRepo.GetPathfindersByClass(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetChildrenByFather(int id)
    {
        try
        {
            return await _personRepo.GetChildrenByFather(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetManagers()
    {
        try
        {
            return await _personRepo.GetManagers();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetInstructors()
    {
        try
        {
            return await _personRepo.GetInstructors();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetFathers()
    {
        try
        {
            return await _personRepo.GetFathers();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<Person> GetPathfinderById(int id)
    {
        try
        {
            return await _personRepo.GetPathfinderById(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<Person> GetPersonClassById(int id)
    {
        try
        {
            return await _personRepo.GetPersonClassById(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetPathfinders()
    {
        try
        {
            return await _personRepo.GetPathfinders();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Person>> GetParents()
    {
        try
        {
            return await _personRepo.GetParents();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> Insert(Person model)
    {
        try
        {
            var result = await _personRepo.Insert(model);
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}