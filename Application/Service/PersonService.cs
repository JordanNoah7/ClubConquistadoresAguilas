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
        return await _personRepo.Insert(model);
    }

    public async Task<bool> Update(Person model)
    {
        return await _personRepo.Update(model);
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        return await _personRepo.Delete(id1);
    }

    public async Task<Person> Get(int id1, int id2 = 0)
    {
        return await _personRepo.Get(id1);
    }

    public async Task<IQueryable<Person>> GetAll()
    {
        return await _personRepo.GetAll();
    }
}