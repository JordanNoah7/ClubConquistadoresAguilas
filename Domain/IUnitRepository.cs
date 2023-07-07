using Models;

namespace Domain;

public interface IUnitRepository
{
    Task<IEnumerable<Unit>> GetUnits();
}