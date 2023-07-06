using Models;

namespace Domain;

public interface IUserRepository
{
    Task<User> GetUserRolByUsername(string username);
}