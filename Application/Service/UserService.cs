using Application.IService;
using Domain;
using Models;

namespace Application.Service;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepo;

    public UserService(IGenericRepository<User> userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<bool> Insert(User model)
    {
        try
        {
            await _userRepo.BeginTransaction();
            bool result = await _userRepo.Insert(model);
            if (result)
                await _userRepo.Commit();
            else
                await _userRepo.Rollback();
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
            await _userRepo.BeginTransaction();
            bool result = await _userRepo.Update(model);
            if (result)
                await _userRepo.Commit();
            else
                await _userRepo.Rollback();
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
            await _userRepo.BeginTransaction();
            bool result = await _userRepo.Delete(id1);
            if (result)
                await _userRepo.Commit();
            else
                await _userRepo.Rollback();
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

    public async Task<IQueryable<User>> GetAll()
    {
        return await _userRepo.GetAll();
    }

    public async Task<User> GetByUsername(string username)
    {
        var queryUserSQL = await _userRepo.GetAll();
        var user = queryUserSQL.Where(u => u.UserName == username).FirstOrDefault();
        return user;
    }
}