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