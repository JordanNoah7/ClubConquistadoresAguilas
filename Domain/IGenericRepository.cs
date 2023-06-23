namespace Domain;

public interface IGenericRepository<TEntityModel> where TEntityModel : class
{
    Task<bool> Insert(TEntityModel model);
    Task<bool> Update(TEntityModel model);
    Task<bool> Delete(int id1, int id2 = 0);
    Task<TEntityModel> Get(int id1, int id2 = 0);
    Task<IEnumerable<TEntityModel>> GetAll();
    Task BeginTransaction();
    Task Commit();
    Task Rollback();
}