using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class RoleRepository : ConnectionRepository, IGenericRepository<Role>
{
    public RoleRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Role model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Roles.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Role model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Roles.Update(model);
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
            var model = _dbContext.Roles.First(c => c.Id == id1);
            _dbContext.Roles.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Role> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Roles.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Role>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Role> queryRolesSQL = _dbContext.Roles;
            return queryRolesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}