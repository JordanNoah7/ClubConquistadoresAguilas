using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class PositionPersonUnitRepository: ContextRepository, IGenericRepository<PositionPersonUnit>
{
    public PositionPersonUnitRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(PositionPersonUnit model)
    {
        try
        {
            _dbContext.PositionPersonUnits.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(PositionPersonUnit model)
    {
        try
        {
            _dbContext.PositionPersonUnits.Update(model);
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
            PositionPersonUnit model = _dbContext.PositionPersonUnits.First(c => c.PositionId == id);
            _dbContext.PositionPersonUnits.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<PositionPersonUnit> Get(int id)
    {
        try
        {
            return await _dbContext.PositionPersonUnits.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<PositionPersonUnit>> GetAll()
    {
        try
        {
            IQueryable<PositionPersonUnit> queryPosPerUniSQL = _dbContext.PositionPersonUnits;
            return queryPosPerUniSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}