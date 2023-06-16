using Infrastructure.Context;
using Models;

namespace DataAccess.Repositories;

public class CategoryRepository: ContextRepository , IGenericRepository<Category>
{
    public CategoryRepository(ClubConquistadoresAguilasContext context) : base(context) { }
    
    public async Task<bool> Insert(Category model)
    {
        try
        {
            _dbContext.Categories.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(Category model)
    {
        try
        {
            _dbContext.Categories.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            Category model = _dbContext.Categories.First(c => c.Id == id);
            _dbContext.Categories.Remove(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<Category> Get(int id)
    {
        try
        {
            return await _dbContext.Categories.FindAsync(id);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IQueryable<Category>> GetAll()
    {
        try
        {
            IQueryable<Category> queryCategoriesSQL = _dbContext.Categories;
            return queryCategoriesSQL;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}