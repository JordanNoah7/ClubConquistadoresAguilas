﻿using Domain;
using Infrastructure.Context;
using Models;

namespace DataAccess;

public class ClubRepository : ContextRepository, IGenericRepository<Club>
{
    public ClubRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

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

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        try
        {
            var model = _dbContext.Clubs.First(c => c.Id == id1);
            _dbContext.Clubs.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
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

    public async Task<IEnumerable<Club>> GetAll()
    {
        try
        {
            IEnumerable<Club> queryClubsSQL = _dbContext.Clubs;
            return queryClubsSQL;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}