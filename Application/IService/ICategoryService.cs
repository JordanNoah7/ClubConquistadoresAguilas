using Models;

namespace Application.IService;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategories();
}