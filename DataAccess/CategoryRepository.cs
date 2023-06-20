using Infrastructure.Context;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Repositories;

public class CategoryRepository: ContextRepository , IGenericRepository<Category>
{
    public CategoryRepository(ClubConquistadoresAguilasContext context) : base(context) { }
    
    public async Task<bool> Insert(Category model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Categories.Add(model);
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

    public async Task<bool> Update(Category model)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                _dbContext.Categories.Update(model);
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

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                Category model = _dbContext.Categories.First(c => c.Id == id1);
                _dbContext.Categories.Remove(model);
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

    public async Task<Category> Get(int id1, int id2 = 0)
    {
        try
        {
            return await _dbContext.Categories.FindAsync(id1);
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