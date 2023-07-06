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

    /*public async Task<bool> Update(Person model)
    {
        try
        {
            var result = await _personRepo.Update(model);
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        try
        {
            var result = await _personRepo.Delete(id1);
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Person> Get(int id1, int id2 = 0)
    {
        return await _personRepo.Get(id1);
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        return await _personRepo.GetAll();
    }*/
}