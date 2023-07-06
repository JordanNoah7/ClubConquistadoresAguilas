using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class PermissionRepository : ConnectionRepository, IGenericRepository<Permission>
{
    public PermissionRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Permission model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Permissions.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Permission model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Permissions.Update(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }*/
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            var model = _dbContext.Permissions.First(p => p.Id.Equals(id1));
            _dbContext.Permissions.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }*/
    }

    public async Task<Permission> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Permissions.FindAsync(id1);
        }
        catch (Exception e)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Permission>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Permission> queryPermissionsSQL = _dbContext.Permissions;
            return queryPermissionsSQL;
        }
        catch (Exception e)
        {
            return null;
        }*/
    }
}