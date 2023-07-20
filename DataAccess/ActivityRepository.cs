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


    public async Task<Activity> GetActivitie(int id)
    {
        Activity activity = new Activity();
        using (var cnDb=Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetActivity", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        if (await dr.ReadAsync())
                        {
                            activity.Name = dr["name"].ToString();
                            activity.StartDate = Convert.ToDateTime(dr["startDate"]);
                            activity.EndDate = Convert.ToDateTime(dr["endDate"]);
                            activity.Location = dr["location"].ToString();
                            activity.Description = dr["description"].ToString();
                            activity.Requirements = dr["requirements"].ToString();
                            activity.Manager = new Person()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                            };
                            Array.Copy((byte[])dr["concurrencyActivity"], activity.ConcurrencyActivity, 8);

                        }
                    }
                    Connection.CloseConnection();
                }

                return activity;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return activity;
            }
        }
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

    public async Task<IEnumerable<Person>> GetParticipants(int id)
    {
        var participantList = new List<Person>();
        using (var cnDb=Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetParticipants", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            participantList.Add(new Person()
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                FirstName = dr["firstName"].ToString(),
                                FathersSurname = dr["fathersSurname"].ToString(),
                                MothersSurname = dr["mothersSurname"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return participantList;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return new List<Person>();
            }
        }
    }

    public async Task<IEnumerable<Person>> GetNoParticipants(int id)
    {
        var noParticipantList = new List<Person>();
        using (var cnDb=Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetNoParticipants", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            noParticipantList.Add(new Person()
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                FirstName = dr["firstName"].ToString(),
                                FathersSurname = dr["fathersSurname"].ToString(),
                                MothersSurname = dr["mothersSurname"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return noParticipantList;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return new List<Person>();
            }
        }
    }

    public async Task<bool> InsertParticipant(int activityId, int personId)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_InsertParticipant", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", activityId);
                    cmd.Parameters.AddWithValue("@PersonId", personId);
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

    public async Task<bool> UpdateActivity(Activity model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_UpdateActivity", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", model.Id);
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@startDate", model.StartDate);
                    cmd.Parameters.AddWithValue("@endDate", model.EndDate);
                    cmd.Parameters.AddWithValue("@location", model.Location);
                    cmd.Parameters.AddWithValue("@description", model.Description);
                    cmd.Parameters.AddWithValue("@requirements", model.Requirements);
                    cmd.Parameters.AddWithValue("@manager", model.Manager.Id);
                    cmd.Parameters.AddWithValue("@concurrency", model.ConcurrencyActivity);
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

    public async Task<bool> DeleteActivity(int id)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_DeleteActivity", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", id);
                    //cmd.Parameters.AddWithValue("@concurrency", model.ConcurrencyActivity);
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

    public async Task<bool> DeleteParticipant(int activityId, int personId)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_DeleteParticipant", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActivityId", activityId);
                    cmd.Parameters.AddWithValue("@PersonId", personId);
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