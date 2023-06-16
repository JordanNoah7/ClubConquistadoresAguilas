using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> Delete(int id1, int id2)
    {
        try
        {
            PositionPersonActivity model = _dbContext.PositionPersonActivities.First(ppa => ppa.ActivityId == id1 && ppa.PersonId == id2);
            _dbContext.PositionPersonActivities.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<PositionPersonActivity> Get(int id1, int id2)
    {
        try
        {
            return await _dbContext.PositionPersonActivities.FirstOrDefaultAsync(ppa => ppa.ActivityId == id1 && ppa.PersonId == id2);
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