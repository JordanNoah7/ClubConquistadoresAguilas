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
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}