using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class UserRepository : ContextRepository, IGenericRepository<User>
{
    public UserRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(User model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(User model)
    {
        throw new Exception();
/*        try
        {
            _dbContext.Users.Update(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            var model = _dbContext.Users.First(u => u.Id == id1);
            _dbContext.Users.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<User> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Users.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        throw new Exception();
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
        }*/
    }
}