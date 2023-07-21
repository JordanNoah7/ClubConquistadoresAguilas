using Models;

namespace Domain;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategories();
}