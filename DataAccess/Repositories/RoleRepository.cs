using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class RoleRepository: ContextRepository, IGenericRepository<Role>
{
    public RoleRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Role model)
    {
        try
        {
            _dbContext.Roles.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Role model)
    {
        try
        {
            _dbContext.Roles.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Role model = _dbContext.Roles.First(c => c.Id == id);
            _dbContext.Roles.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Role> Get(int id)
    {
        try
        {
            return await _dbContext.Roles.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Role>> GetAll()
    {
        try
        {
            IQueryable<Role> queryRolesSQL = _dbContext.Roles;
            return queryRolesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}