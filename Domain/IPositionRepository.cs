using Models;

namespace Domain;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> GetPositions();
}