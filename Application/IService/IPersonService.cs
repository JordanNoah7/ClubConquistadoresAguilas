using Models;

namespace Application.IService;

public interface IPersonService
{
    Task<bool> Insert(Person model);
    Task<IEnumerable<Person>> GetFathers();
    Task<Person> GetPathfinderById(int id);
    Task<Person> GetPersonClassById(int id);
    Task<IEnumerable<Person>> GetPathfinders();
}