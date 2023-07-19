using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class ActivityRepository : ConnectionRepository, IActivityRepository
{
    public ActivityRepository(IConfiguration configuration) : base(configuration)
    {
    }


    public async Task<IEnumerable<Activity>> GetActivities()
    {
        var activityList = new List<Activity>();
        using (var cnDb=Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetActivities", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            activityList.Add(new Activity()
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                Name = dr["name"].ToString(),
                                StartDate = Convert.ToDateTime(dr["startDate"]),
                                EndDate = Convert.ToDateTime(dr["endDate"]),
                                Manager = new Person()
                                {
                                    Id = Convert.ToInt32(dr["PersonID"]),
                                    FirstName = dr["firstName"].ToString(),
                                    FathersSurname = dr["fathersSurname"].ToString(),
                                    MothersSurname = dr["mothersSurname"].ToString()
                                },
                                Location = dr["location"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return activityList;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return new List<Activity>();
            }
        }
    }

    public async Task<bool> Insert(Activity model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_InsertActivity", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@startDate", model.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", model.EndDate);
                    cmd.Parameters.AddWithValue("@location", model.Location);
                    cmd.Parameters.AddWithValue("@description", model.Description);
                    cmd.Parameters.AddWithValue("@requirements", model.Requirements);
                    cmd.Parameters.AddWithValue("@manager", model.Manager.Id);
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