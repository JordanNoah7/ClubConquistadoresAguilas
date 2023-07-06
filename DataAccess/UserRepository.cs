using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class UserRepository : ConnectionRepository, IUserRepository
{
    public UserRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<User> GetUserRolByUsername(string username)
    {
        var user = new User();
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetUserRolByUsername", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        if (await dr.ReadAsync())
                        {
                            user.Id = Convert.ToInt32(dr["User_ID"].ToString());
                            user.UserName = username;
                            user.Password = dr["password"].ToString();
                            user.ConcurrencyUser = dr["concurrencyUser"];
                            var role = new Role();
                            role.Id = Convert.ToByte(dr["Rol_ID"].ToString());
                            role.Name = dr["name"].ToString();
                            user.UserRols = new List<UserRol>
                            {
                                new()
                                {
                                    Rol = role
                                }
                            };
                        }
                    }

                    Connection.CloseConnection();
                }

                return user;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

/*    public async Task<bool> Insert(User model)
    {
        throw new Exception();
        try
        {
            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Update(User model)
    {
        throw new Exception();
        try
        {
            _dbContext.Users.Update(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        throw new Exception();
        try
        {
            var model = _dbContext.Users.First(u => u.Id == id1);
            _dbContext.Users.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<User> Get(int id1, int id2 = 0)
    {
        throw new Exception();
        try
        {
            return await _dbContext.Users.FindAsync(id1);
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        throw new Exception();
        
            try
            {
                IQueryable<User> queryUsersSQL = _dbContext.Users;
                return queryUsersSQL;
        
            }
            catch (Exception ex)
            {
                return null;
        
            }
        
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                IEnumerable<User> queryUsersSql = _dbContext.Set<User>().FromSqlRaw("EXECUTE usp_GetUsers").ToList();
                await transaction.CommitAsync();
                return queryUsersSql;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }*/
}