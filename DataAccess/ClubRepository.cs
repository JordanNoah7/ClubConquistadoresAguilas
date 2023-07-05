using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class ClubRepository : ConnectionRepository, IGenericRepository<Club>
{
    public ClubRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Club model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Clubs.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Club model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Clubs.Update(model);
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
            var model = _dbContext.Clubs.First(c => c.Id == id1);
            _dbContext.Clubs.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }*/
    }

    public async Task<Club> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Clubs.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Club>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Club> queryClubsSQL = _dbContext.Clubs;
            return queryClubsSQL;
        }
        catch (Exception e)
        {
            return null;
        }*/
    }
}