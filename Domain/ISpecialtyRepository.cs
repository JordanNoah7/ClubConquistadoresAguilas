using Models;

namespace Domain;

public interface ISpecialtyRepository
{
    Task<IEnumerable<Specialty>> GetSpecialties(int id);
    Task<bool> InsertNote(Specialty model);
}