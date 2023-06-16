using Application.IService;
using Domain;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Application.Service;

public class UserService: IUserService
{
    private readonly IGenericRepository<User> _userRepo;
    
    public UserService(IGenericRepository<User> userRepo)
    {
        _userRepo = userRepo;
    }
    
    public async Task<bool> Insert(User model)
    {
        return await _userRepo.Insert(model);
    }

    public async Task<bool> Update(User model)
    {
        return await _userRepo.Update(model);
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        return await _userRepo.Delete(id1);
    }

    public async Task<User> Get(int id1, int id2 = 0)
    {
        return await _userRepo.Get(id1);
    }

    public async Task<IQueryable<User>> GetAll()
    {
        return await _userRepo.GetAll();
    }

    public async Task<User> GetByUsernamePassword(string username, string password)
    {
        IQueryable<User> queryUserSQL = await _userRepo.GetAll();
        User user = queryUserSQL.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
        return user;
    }
}