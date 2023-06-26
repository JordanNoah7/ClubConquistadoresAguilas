using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class PersonRepository : ContextRepository, IGenericRepository<Person>
{
    public PersonRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

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

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        try
        {
            var model = _dbContext.People.First(p => p.Id.Equals(id1));
            _dbContext.People.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<Person> Get(int id1, int id2 = 0)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                //return await _dbContext.People.FindAsync(id1);
                var query = _dbContext.People
                    .FromSqlRaw("EXECUTE usp_GetPerson @PersonID", new SqlParameter("@PersonID", id1)).AsEnumerable()
                    .FirstOrDefault();
                await transaction.CommitAsync();
                return query;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        try
        {
            IEnumerable<Person> queryPeopleSQL = _dbContext.People;
            return queryPeopleSQL;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}