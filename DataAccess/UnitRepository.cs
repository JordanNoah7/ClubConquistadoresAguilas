using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess;

public class UnitRepository : ContextRepository, IGenericRepository<Unit>
{
    public UnitRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(Unit model)
    {
        
            try
            {
                _dbContext.Units.Add(model);
                await _dbContext.SaveChangesAsync();
        
                return true;
            }
            catch (Exception ex)
            {
        
                return false;
            }
        
    }

    public async Task<bool> Update(Unit model)
    {
        
            try
            {
                _dbContext.Units.Add(model);
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
                var model = _dbContext.Units.First(u => u.Id == id1);
                _dbContext.Units.Remove(model);
                await _dbContext.SaveChangesAsync();
        
                return true;
            }
            catch (Exception ex)
            {
        
                return false;
            }
        
    }

    public async Task<Unit> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Units.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IEnumerable<Unit>> GetAll()
    {
        try
        {
 IEnumerable<Unit> queryUnitsSQL = _dbContext.Units;
            return queryUnitsSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}