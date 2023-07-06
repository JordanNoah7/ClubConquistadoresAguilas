using Models;

namespace Application.IService;

public interface IUnitService
{
    Task<IEnumerable<Unit>> GetUnits();
}