using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class PositionPersonUnitRepository : ContextRepository, IGenericRepository<PositionPersonUnit>
{
    public PositionPersonUnitRepository(ClubConquistadoresAguilasContext context) : base(context)
    {
    }

    public async Task<bool> Insert(PositionPersonUnit model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.PositionPersonUnits.Add(model);
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

    public async Task<bool> Update(PositionPersonUnit model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.PositionPersonUnits.Update(model);
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

    public async Task<bool> Delete(int id1, int id2)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                var model =
                    _dbContext.PositionPersonUnits.First(ppu => ppu.UnitId == id1 && ppu.PersonId == id2);
                _dbContext.PositionPersonUnits.Remove(model);
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

    public async Task<PositionPersonUnit> Get(int id1, int id2)
    {
        try
        {
            return await _dbContext.PositionPersonUnits.FirstOrDefaultAsync(ppu =>
                ppu.UnitId == id1 && ppu.PersonId == id2);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<PositionPersonUnit>> GetAll()
    {
        try
        {
            IQueryable<PositionPersonUnit> queryPosPerUniSQL = _dbContext.PositionPersonUnits;
            return queryPosPerUniSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}