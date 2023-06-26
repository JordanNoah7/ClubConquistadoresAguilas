using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class PersonService : IPersonService
{
    private readonly IGenericRepository<Person> _personRepo;

    public PersonService(IGenericRepository<Person> personRepo)
    {
        _personRepo = personRepo;
    }

    public async Task<bool> Insert(Person model)
    {
        try
        {
            await _personRepo.BeginTransaction();
            var result = await _personRepo.Insert(model);
            if (result)
                await _personRepo.Commit();
            else
                await _personRepo.Rollback();
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Person model)
    {
        try
        {
            await _personRepo.BeginTransaction();
            var result = await _personRepo.Update(model);
            if (result)
                await _personRepo.Commit();
            else
                await _personRepo.Rollback();
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
            await _personRepo.BeginTransaction();
            var result = await _personRepo.Delete(id1);
            if (result)
                await _personRepo.Commit();
            else
                await _personRepo.Rollback();
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
    }
}