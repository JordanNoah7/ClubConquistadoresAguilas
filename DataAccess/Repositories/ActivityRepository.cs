using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class ActivityRepository:ContextRepository,IGenericRepository<Activity>
{
    /*private readonly ClubConquistadoresAguilasContext _dbContext;
    
    public ActivityRepository(ClubConquistadoresAguilasContext context)
    {
        _dbContext = context;
    }*/

    public ActivityRepository(ClubConquistadoresAguilasContext context) : base(context) { }
    
    public async Task<bool> Insert(Activity model)
    {
        try
        {
            _dbContext.Activities.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Activity model)
    {
        try
        {
            _dbContext.Activities.Update(model);
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
            Activity model = _dbContext.Activities.First(a => a.Id == id);
            _dbContext.Activities.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Activity> Get(int id)
    {
        try
        {
            return await _dbContext.Activities.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Activity>> GetAll()
    {
        try
        {
            IQueryable<Activity> queryActivitiesSQL = _dbContext.Activities;
            return queryActivitiesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}