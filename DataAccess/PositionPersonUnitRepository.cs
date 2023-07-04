using Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class PositionPersonUnitRepository : ContextRepository, IGenericRepository<PositionPersonUnit>
{
    public PositionPersonUnitRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(PositionPersonUnit model)
    {throw new Exception();
        /*try
        {
            _dbContext.PositionPersonUnits.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(PositionPersonUnit model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.PositionPersonUnits.Update(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Delete(int id1, int id2)
    {
        throw new Exception();
        /*try
        {
            var model =
                _dbContext.PositionPersonUnits.First(ppu => ppu.UnitId == id1 && ppu.PersonId == id2);
            _dbContext.PositionPersonUnits.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<PositionPersonUnit> Get(int id1, int id2)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.PositionPersonUnits.FirstOrDefaultAsync(ppu =>
                ppu.UnitId == id1 && ppu.PersonId == id2);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<PositionPersonUnit>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<PositionPersonUnit> queryPosPerUniSQL = _dbContext.PositionPersonUnits;
            return queryPosPerUniSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}