using Domain;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class SpecialtyRepository : ContextRepository, IGenericRepository<Specialty>
{
    public SpecialtyRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Specialty model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Specialties.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Specialty model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Specialties.Update(model);
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
            var model = _dbContext.Specialties.First(s => s.Id == id1);
            _dbContext.Specialties.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Specialty> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Specialties.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Specialty>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Specialty> querySpecialtiesSQL = _dbContext.Specialties;
            return querySpecialtiesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}