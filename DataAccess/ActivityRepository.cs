using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess;

public class ActivityRepository : ContextRepository, IGenericRepository<Activity>
{
    public ActivityRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(Activity model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Activities.Add(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<bool> Update(Activity model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Activities.Update(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var model = _dbContext.Activities.First(a => a.Id == id1);
                _dbContext.Activities.Remove(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<Activity> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Activities.FindAsync(id1);
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