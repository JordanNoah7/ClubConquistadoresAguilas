using Models;

namespace Domain;

public interface IUserPersonRepository
{
    Task<bool> Insert(User user, Person person);
    Task<bool> Delete(int id1);
}