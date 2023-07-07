using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class UnitRepository : ConnectionRepository, IUnitRepository
{
    public UnitRepository(IConfiguration configuration) : base(configuration)
    {
    }
    
    public async Task<IEnumerable<Unit>> GetUnits()
    {
        var unitList = new List<Unit>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetUnits", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            unitList.Add(new Unit()
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                Name = dr["name"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return unitList;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}