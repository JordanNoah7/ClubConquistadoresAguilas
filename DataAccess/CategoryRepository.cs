using Domain;
using Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class CategoryRepository : ContextRepository, IGenericRepository<Category>
{
    public CategoryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Category model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Categories.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Category model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.Categories.Update(model);
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
            var model = _dbContext.Categories.First(c => c.Id == id1);
            _dbContext.Categories.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }*/
    }

    public async Task<Category> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            return await _dbContext.Categories.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Category> queryCategoriesSQL = _dbContext.Categories;
            return queryCategoriesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }*/
    }
}