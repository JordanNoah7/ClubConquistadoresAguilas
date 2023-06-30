using Models;

namespace Domain;

public interface UserPersonRepository
{
    Task<bool> Insert(User user, Person person);
    Task<bool> Update(User user, Person person);
    Task<bool> Delete(int id1);
    Task<Person> Get(int id1);
    Task<IEnumerable<Person>> GetAll();
}