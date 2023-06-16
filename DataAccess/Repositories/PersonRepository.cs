using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class PersonRepository:ContextRepository,IGenericRepository<Person>
{
    public PersonRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Person model)
    {
        try
        {
            _dbContext.People.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
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
            _dbContext.People.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Person model = _dbContext.People.First(p => p.Id.Equals(id));
            _dbContext.People.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<Person> Get(int id)
    {
        try
        {
            return await _dbContext.People.FindAsync(id);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IQueryable<Person>> GetAll()
    {
        try
        {
            IQueryable<Person> queryPeopleSQL = _dbContext.People;
            return queryPeopleSQL;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}