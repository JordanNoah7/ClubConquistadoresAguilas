using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class PositionPersonActivityRepository: ContextRepository, IGenericRepository<PositionPersonActivity>
{
    public PositionPersonActivityRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(PositionPersonActivity model)
    {
        try
        {
            _dbContext.PositionPersonActivities.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(PositionPersonActivity model)
    {
        try
        {
            _dbContext.PositionPersonActivities.Update(model);
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
            PositionPersonActivity model = _dbContext.PositionPersonActivities.First(c => c.ActivityId == id);
            _dbContext.PositionPersonActivities.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<PositionPersonActivity> Get(int id)
    {
        try
        {
            return await _dbContext.PositionPersonActivities.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<PositionPersonActivity>> GetAll()
    {
        try
        {
            IQueryable<PositionPersonActivity> queryPosPerActSQL = _dbContext.PositionPersonActivities;
            return queryPosPerActSQL;
        }
        catch (Exception ex)    
        {
            return null;
        }
    }
}