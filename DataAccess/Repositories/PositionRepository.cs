﻿using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class PositionRepository:ContextRepository, IGenericRepository<Position>
{
    public PositionRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Position model)
    {
        try
        {
            _dbContext.Positions.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Position model)
    {
        try
        {
            _dbContext.Positions.Update(model);
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
            Position model = _dbContext.Positions.First(p => p.Id == id1);
            _dbContext.Positions.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Position> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Positions.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Position>> GetAll()
    {
        try
        {
            IQueryable<Position> queryPositionsSQL = _dbContext.Positions;
            return queryPositionsSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}