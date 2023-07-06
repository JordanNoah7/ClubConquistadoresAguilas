using Models;

namespace Application.IService;

public interface IPositionService
{
    Task<IEnumerable<Position>> GetPositions();
}