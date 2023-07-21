using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<Class>> GetClasses()
    {
        return await _classRepository.GetClasses();
    }
}