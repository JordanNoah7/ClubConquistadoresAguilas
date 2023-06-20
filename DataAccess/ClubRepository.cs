using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class ClubRepository : ContextRepository, IGenericRepository<Club>
{
    public ClubRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(Club model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Clubs.Add(model);
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

    public async Task<bool> Update(Club model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Clubs.Update(model);
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
                var model = _dbContext.Clubs.First(c => c.Id == id1);
                _dbContext.Clubs.Remove(model);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }
    }

    public async Task<Club> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Clubs.FindAsync(id1);
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