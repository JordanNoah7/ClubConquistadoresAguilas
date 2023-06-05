using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class ClubRepository:ContextRepository, IGenericRepository<Club>
{
    public ClubRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Club model)
    {
        try
        {
            _dbContext.Clubs.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Club model)
    {
        try
        {
            _dbContext.Clubs.Update(model);
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
            Club model = _dbContext.Clubs.First(c => c.Id == id);
            _dbContext.Clubs.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<Club> Get(int id)
    {
        try
        {
            return await _dbContext.Clubs.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Club>> GetAll()
    {
        try
        {
            IQueryable<Club> queryClubsSQL = _dbContext.Clubs;
            return queryClubsSQL;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}