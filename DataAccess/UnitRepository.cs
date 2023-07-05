using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class UnitRepository : ConnectionRepository, IGenericRepository<Unit>
{
    public UnitRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Unit model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Units.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Unit model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Units.Add(model);
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
            var model = _dbContext.Units.First(u => u.Id == id1);
            _dbContext.Units.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Unit> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Units.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Unit>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Unit> queryUnitsSQL = _dbContext.Units;
            return queryUnitsSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}