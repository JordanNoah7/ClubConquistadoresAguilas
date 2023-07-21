using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class UnitService : IUnitService
{
    private readonly IUnitRepository _unitRepository;

    public UnitService(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<IEnumerable<Unit>> GetUnits()
    {
        return await _unitRepository.GetUnits();
    }
}