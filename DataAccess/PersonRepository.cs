using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class PersonRepository : ConnectionRepository, IPersonRepository
{
    public PersonRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Person model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_InsertPerson", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@DNI", model.Dni);
                    cmd.Parameters.AddWithValue("@firstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@fathersSurname", model.FathersSurname);
                    cmd.Parameters.AddWithValue("@mothersSurname", model.MothersSurname);
                    cmd.Parameters.AddWithValue("@birthDate", model.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", model.Gender);
                    cmd.Parameters.AddWithValue("@address", model.Address);
                    cmd.Parameters.AddWithValue("@phone", model.Phone);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@ClubID", model.ClubId);
                    cmd.Parameters.AddWithValue("@userName", model.User.UserName);
                    cmd.Parameters.AddWithValue("@password", model.User.Password);
                    cmd.Parameters.AddWithValue("@FatherID", model.PersonId.Equals(0)?null:model.PersonId);
                    cmd.Parameters.AddWithValue("@ClassID", model.ClassPeople.FirstOrDefault().ClassId);
                    cmd.Parameters.AddWithValue("@UnitID", model.PositionPersonUnits.FirstOrDefault().UnitId);
                    cmd.Parameters.AddWithValue("@PositionID", model.PositionPersonUnits.FirstOrDefault().PositionId);
                    cmd.Parameters.AddWithValue("@RoleID", model.User.UserRols.FirstOrDefault().RolId);
                    Connection.OpenConnection();
                    await cmd.ExecuteNonQueryAsync();
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

    public async Task<bool> Update(Person model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_UpdatePerson", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
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
                    await cmd.ExecuteNonQueryAsync();
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

    /*public async Task<Person> Get(int id1, int id2 = 0)
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
    }*/

    /*public async Task<IEnumerable<Person>> GetAll()
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
        }#1#
    }*/

    public async Task<Person> GetPersonClassById(int id)
    {
        var person = new Person();
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetPersonClassByID", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PersonID", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        if (await dr.ReadAsync())
                        {
                            person.FirstName = dr["firstname"].ToString();
                            person.FathersSurname = dr["fathersSurname"].ToString();
                            person.MothersSurname = dr["mothersSurname"].ToString();
                            person.ClassPeople = new List<ClassPerson>
                            {
                                new()
                                {
                                    ClassId = Convert.ToByte(dr["ClassID"])
                                }
                            };
                        }
                    }

                    Connection.CloseConnection();
                }

                return person;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetPathfinders()
    {
        var pathfinderList = new List<Person>();
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetPathfinders", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                            pathfinderList.Add(new Person
                            {
                                Id = Convert.ToInt32(dr["PeopleID"].ToString()),
                                FirstName = dr["firstName"].ToString(),
                                FathersSurname = dr["fathersSurname"].ToString(),
                                MothersSurname = dr["mothersSurname"].ToString(),
                                ClassPeople = new List<ClassPerson>
                                {
                                    new()
                                    {
                                        Class = new Class
                                        {
                                            Name = dr["class"].ToString()
                                        }
                                    }
                                },
                                PositionPersonUnits = new List<PositionPersonUnit>
                                {
                                    new()
                                    {
                                        Unit = new Unit
                                        {
                                            Name = dr["unit"].ToString()
                                        },
                                        Position = new Position
                                        {
                                            Name = dr["position"].ToString()
                                        }
                                    }
                                }
                            });
                    }

                    Connection.CloseConnection();
                }

                return pathfinderList;
            }
            catch (Exception ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}