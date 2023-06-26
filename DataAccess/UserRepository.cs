using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess;

public class UserRepository : ContextRepository, IGenericRepository<User>
{
    public UserRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(User model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Users.Add(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<bool> Update(User model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Users.Update(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var model = _dbContext.Users.First(u => u.Id == id1);
                _dbContext.Users.Remove(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
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

    public async Task<IQueryable<User>> GetAll()
    {
        try
        {
            IQueryable<User> queryUsersSQL = _dbContext.Users;
            return queryUsersSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}