using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class PositionService : IPositionService
{
    private readonly IPositionRepository _positionRepository;

    public PositionService(IPositionRepository positionRepository)
    {
        _positionRepository = positionRepository;
    }

    public async Task<IEnumerable<Position>> GetPositions()
    {
        return await _positionRepository.GetPositions();
    }
}