using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class AttendanceRepository : ConnectionRepository, IAttendanceRepository
{
    public AttendanceRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Attendance model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_InsertAttendance", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PersonID", model.PersonId);
                    cmd.Parameters.AddWithValue("@frecuency", model.Frecuency);
                    cmd.Parameters.AddWithValue("@devotion", model.Devotion);
                    cmd.Parameters.AddWithValue("@monthly", model.Monthly);
                    cmd.Parameters.AddWithValue("@discipline", model.Discipline);
                    cmd.Parameters.AddWithValue("@year", model.Year);
                    cmd.Parameters.AddWithValue("@requeriments", model.Requeriments);
                    Connection.OpenConnection();
                    await cmd.ExecuteNonQueryAsync();
                    Connection.CloseConnection();
                }

                return true;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return false;
            }
        }
    }
}