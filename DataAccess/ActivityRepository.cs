using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class ActivityRepository : ConnectionRepository, IGenericRepository<Activity>
{
    public ActivityRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Activity model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Activities.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Activity model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Activities.Update(model);
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
            var model = _dbContext.Activities.First(a => a.Id == id1);
            _dbContext.Activities.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Activity> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Activities.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Activity>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Activity> queryActivitiesSQL = _dbContext.Activities;
            return queryActivitiesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}