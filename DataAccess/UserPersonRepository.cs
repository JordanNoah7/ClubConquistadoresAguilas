using Domain;
using Models;

namespace DataAccess;

public class UserPersonRepository : IUserPersonRepository
{
    public async Task<bool> Insert(User user, Person person)
    {
        try
        {
            
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public Task<bool> Delete(int id1)
    {
        throw new Exception();
    }
}