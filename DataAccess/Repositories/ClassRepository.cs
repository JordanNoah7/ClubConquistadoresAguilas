using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class ClassRepository:ContextRepository, IGenericRepository<Class>
{
    public ClassRepository(ClubConquistadoresAguilasContext context) : base(context) { }

    public async Task<bool> Insert(Class model)
    {
        try
        {
            _dbContext.Classes.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Class model)
    {
        try
        {
            _dbContext.Classes.Update(model);
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
            Class model = _dbContext.Classes.First(c => c.Id == id1);
            _dbContext.Classes.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Class> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Classes.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Class>> GetAll()
    {
        try
        {
            IQueryable<Class> queryClassesSQL = _dbContext.Classes;
            return queryClassesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}