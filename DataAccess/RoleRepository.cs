using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class RoleRepository : ConnectionRepository, IRoleRepository
{
    public RoleRepository(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<IEnumerable<Role>> GetRoles()
    {
        var roleList = new List<Role>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetRoles", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            roleList.Add(new Role()
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                Name = dr["name"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }
                return roleList;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}