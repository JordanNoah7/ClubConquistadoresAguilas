using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class UserRepository : ContextRepository, IGenericRepository<User>
{
    public UserRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(User model)
    {
        try
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(User model)
    {
        try
        {
            _dbContext.Users.Update(model);
            await _dbContext.SaveChangesAsync();

            return true;
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
            var model = _dbContext.Users.First(u => u.Id == id1);
            _dbContext.Users.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<User> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Users.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        /*
            try
            {
                IQueryable<User> queryUsersSQL = _dbContext.Users;
                return queryUsersSQL;
        
            }
            catch (Exception ex)
            {
                return null;
        
            }
        */
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                IEnumerable<User> queryUsersSql = _dbContext.Set<User>().FromSqlRaw("EXECUTE usp_GetUsers").ToList();
                await transaction.CommitAsync();
                return queryUsersSql;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}