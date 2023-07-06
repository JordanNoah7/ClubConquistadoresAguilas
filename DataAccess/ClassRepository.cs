using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class ClassRepository : ConnectionRepository, IClassRepository
{
    public ClassRepository(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<IEnumerable<Class>> GetClasses()
    {
        var classList = new List<Class>();
        using (var cnDb=Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetClasses", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            classList.Add(new Class()
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                Name = dr["name"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return classList;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}