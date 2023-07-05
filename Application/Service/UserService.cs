using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<User> GetUserRolByUsername(string username)
    {
        return await _userRepo.GetUserRolByUsername(username);
    }

    /*public async Task<bool> Insert(User model)
    {
        try
        {
            var result = await _userRepo.Insert(model);
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(User model)
    {
        try
        {
            var result = await _userRepo.Update(model);
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        try
        {
            var result = await _userRepo.Delete(id1);
            return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<User> Get(int id1, int id2 = 0)
    {
        return await _userRepo.Get(id1);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepo.GetAll();
    }

    public async Task<User> GetByUsername(string username)
    {
        var queryUserSql = await _userRepo.GetAll();
        var user = queryUserSql.Where(u => u.UserName == username).FirstOrDefault();
        return user;
    }*/
}