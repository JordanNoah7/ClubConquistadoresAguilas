using Models;

namespace Domain;

public interface IPersonRepository
{
    Task<bool> Insert(Person model);
    Task<bool> Update(Person model);
    Task<IEnumerable<Person>> GetFathers();
    Task<Person> GetPersonClassById(int id);
    Task<Person> GetPathfinderById(int id);
    Task<IEnumerable<Person>> GetPathfinders();
}