using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess;

public class PermissionRepository : ContextRepository, IGenericRepository<Permission>
{
    public PermissionRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(Permission model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Permissions.Add(model);
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

    public async Task<bool> Update(Permission model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Permissions.Update(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
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
                var model = _dbContext.Permissions.First(p => p.Id.Equals(id1));
                _dbContext.Permissions.Remove(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<Permission> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Permissions.FindAsync(id1);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<IQueryable<Permission>> GetAll()
    {
        try
        {
            IQueryable<Permission> queryPermissionsSQL = _dbContext.Permissions;
            return queryPermissionsSQL;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}