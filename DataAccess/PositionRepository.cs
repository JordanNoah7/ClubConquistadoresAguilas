using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class PositionRepository : ConnectionRepository, IGenericRepository<Position>
{
    public PositionRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Position model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Positions.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Position model)
    {
        throw new Exception();
        /*
        try
        {
            _dbContext.Positions.Update(model);
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
            var model = _dbContext.Positions.First(p => p.Id == id1);
            _dbContext.Positions.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Position> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Positions.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Position>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Position> queryPositionsSQL = _dbContext.Positions;
            return queryPositionsSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}