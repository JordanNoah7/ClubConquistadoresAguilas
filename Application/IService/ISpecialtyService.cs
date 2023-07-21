using Models;

namespace Application.IService;

public interface ISpecialtyService
{
    Task<IEnumerable<Specialty>> GetSpecialties(int id);
}