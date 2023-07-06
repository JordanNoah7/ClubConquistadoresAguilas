using Domain;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class ClassRepository : ConnectionRepository, IGenericRepository<Class>
{
    public ClassRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Class model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Classes.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Class model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Classes.Update(model);
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
            var model = _dbContext.Classes.First(c => c.Id == id1);
            _dbContext.Classes.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Class> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Classes.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Class>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Class> queryClassesSQL = _dbContext.Classes;
            return queryClassesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}