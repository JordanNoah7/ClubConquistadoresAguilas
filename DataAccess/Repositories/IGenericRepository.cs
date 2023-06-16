namespace DataAccess.Repositories;

public interface IGenericRepository<TEntityModel> where TEntityModel : class
{
    Task<bool> Insert(TEntityModel model);
    Task<bool> Update(TEntityModel model);
    Task<bool> Delete(int id);
    Task<TEntityModel> Get(int id);
    Task<IQueryable<TEntityModel>> GetAll();
}