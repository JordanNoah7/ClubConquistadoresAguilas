using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        try
        {
            return await _categoryRepository.GetCategories();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}