using Models;

namespace Domain;

public interface IClassRepository
{
    Task<IEnumerable<Class>> GetClasses();
}