using Models;

namespace Domain;

public interface IPersonRepository
{
    Task<bool> Update(Person model);
    Task<Person> Get(int id1, int id2 = 0);
    Task<IEnumerable<Person>> GetAll();
}