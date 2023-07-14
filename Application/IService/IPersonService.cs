using Models;

namespace Application.IService;

public interface IPersonService
{
    Task<bool> Insert(Person model);
    Task<bool> Update(Person model);
    Task<Person> GetPathfinderById(int id);
    Task<Person> GetPersonClassById(int id);
    Task<IEnumerable<Person>> GetCounselors();
    Task<IEnumerable<Person>> GetFathers();
    Task<IEnumerable<Person>> GetPathfinders();
}