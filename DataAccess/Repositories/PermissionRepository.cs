using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class PermissionRepository:ContextRepository, IGenericRepository<Permission>
{
    public PermissionRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Permission model)
    {
        try
        {
            _dbContext.Permissions.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Permission model)
    {
        try
        {
            _dbContext.Permissions.Update(model);
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
            Permission model = _dbContext.Permissions.First(p=>p.Id.Equals(id));
            _dbContext.Permissions.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<Permission> Get(int id)
    {
        try
        {
            return await _dbContext.Permissions.FindAsync(id);
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