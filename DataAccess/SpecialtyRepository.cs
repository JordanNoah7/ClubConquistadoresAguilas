using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class SpecialtyRepository : ConnectionRepository, ISpecialtyRepository
{
    public SpecialtyRepository(IConfiguration configuration) : base(configuration)
    {
    }


    public async Task<IEnumerable<Specialty>> GetSpecialties(int id)
    {
        var specialtyList = new List<Specialty>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetSpecialtyByCategory", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CategoryId", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                            specialtyList.Add(new Specialty
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                Name = dr["name"].ToString()
                            });
                    }

                    Connection.CloseConnection();
                }

                return specialtyList;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}