﻿using Models;

namespace Application.IService;

public interface IUserService
{
    Task<User> GetUserRolByUsername(string username);
    /*Task<bool> Insert(User model);
    Task<bool> Update(User model);
    Task<bool> Delete(int id1, int id2 = 0);
    Task<User> Get(int id1, int id2 = 0);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetByUsername(string username);*/
}