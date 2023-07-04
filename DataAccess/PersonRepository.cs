using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class PersonRepository : ContextRepository, IPersonRepository
{
    public PersonRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Update(Person model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_UpdatePerson", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", model.Id);
                    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@fathersSurname", model.FathersSurname);
                    cmd.Parameters.AddWithValue("@mothersSurname", model.MothersSurname);
                    cmd.Parameters.AddWithValue("@birthDate", model.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", model.Gender);
                    cmd.Parameters.AddWithValue("@address", model.Address);
                    cmd.Parameters.AddWithValue("@phone", model.Phone);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@FatherID", model.PersonId);
                    Connection.OpenConnection();
                    cmd.ExecuteNonQuery();
                    Connection.CloseConnection();
                }

                return true;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return false;
            }
        }
    }

    public async Task<Person> Get(int id1, int id2 = 0)
    {
        var model = new Person();
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var command = new SqlCommand("dbo.usp_GetPerson", connectionDb))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PersonID", id1);
                    Connection.OpenConnection();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            model.Id = id1;
                            model.FirstName = reader["firstName"].ToString();
                            model.FathersSurname = reader["fathersSurname"].ToString();
                            model.MothersSurname = reader["mothersSurname"].ToString();
                            model.BirthDate = Convert.ToDateTime(reader["birthDate"]);
                            model.Gender = reader["gender"].ToString();
                            model.Address = reader["address"].ToString();
                            model.Phone = reader["phone"].ToString();
                            model.Email = reader["email"].ToString();
                            model.Club = new Club
                            {
                                Name = reader["club"].ToString()
                            };
                            model.PersonNavigation = new Person
                            {
                                FirstName = reader["fatherName"].ToString(),
                                FathersSurname = reader["fatherSurname"].ToString(),
                                MothersSurname = reader["fatherSurname2"].ToString()
                            };
                        }
                    }

                    Connection.CloseConnection();
                }

                return model;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetAll()
    {
        throw new Exception();
        /*try
        {
            IEnumerable<Person> queryPeopleSQL = _dbContext.People;
            return queryPeopleSQL;
        }
        catch (Exception e)
        {
            return null;
        }*/
    }
}