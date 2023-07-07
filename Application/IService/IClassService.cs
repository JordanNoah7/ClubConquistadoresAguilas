using Models;

namespace Application.IService;

public interface IClassService
{
    Task<IEnumerable<Class>> GetClasses();
}