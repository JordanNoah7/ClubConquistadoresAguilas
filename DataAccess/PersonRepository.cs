﻿using System.Data;
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
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return false;
            }
        }
    }

    public async Task<bool> InsertParent(Person model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_InsertParent", connectionDb))
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
                    cmd.Parameters.AddWithValue("@RoleID", model.User.UserRols.FirstOrDefault().RolId);
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
                    cmd.Parameters.AddWithValue("@FatherID", model.PersonId.Equals(0) ? null : model.PersonId);
                    cmd.Parameters.AddWithValue("@ClassID", model.ClassPeople.FirstOrDefault().ClassId);
                    cmd.Parameters.AddWithValue("@UnitID", model.PositionPersonUnits.FirstOrDefault().UnitId);
                    cmd.Parameters.AddWithValue("@PositionID", model.PositionPersonUnits.FirstOrDefault().PositionId);
                    cmd.Parameters.AddWithValue("@RoleID", model.User.UserRols.FirstOrDefault().RolId);
                    //cmd.Parameters.AddWithValue("@concurrency", model.ConcurrencyPerson);
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

    public async Task<bool> UpdateParent(Person model)
    {
        using (var connectionDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_UpdateParent", connectionDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PersonID", model.Id);
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
                    cmd.Parameters.AddWithValue("@RoleID", model.User.UserRols.FirstOrDefault().RolId);
                    //cmd.Parameters.AddWithValue("@concurrency", model.ConcurrencyPerson);
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
                            person.Id = Convert.ToInt32(dr["ID"].ToString());
                            person.FirstName = dr["firstname"].ToString();
                            person.FathersSurname = dr["fathersSurname"].ToString();
                            person.MothersSurname = dr["mothersSurname"].ToString();
                            person.BirthDate = Convert.ToDateTime(dr["birthDate"].ToString());
                            person.Phone = dr["phone"].ToString();
                            person.Email = dr["email"].ToString();
                            person.ClassPeople = new List<ClassPerson>
                            {
                                new()
                                {
                                    Class = new Class()
                                    {
                                        Id = Convert.ToByte(dr["ClassID"].ToString()),
                                        Name = dr["class"].ToString()
                                    }
                                }
                            };
                            person.PositionPersonUnits = new List<PositionPersonUnit>
                            {
                                new()
                                {
                                    Unit = new Unit()
                                    {
                                        Id = Convert.ToByte(dr["UnitID"].ToString()),
                                        Name = Convert.ToString(dr["unit"])
                                    }
                                }
                            };
                        }
                    }

                    Connection.CloseConnection();
                }

                return person;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<Person> GetPathfinderById(int id)
    {
        Person person = new Person();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetPathfinderById", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        if (await dr.ReadAsync())
                        {
                            person.Id = Convert.ToInt32(dr["ID"]);
                            person.Dni = dr["DNI"].ToString();
                            person.FirstName = dr["firstname"].ToString();
                            person.FathersSurname = dr["fathersSurname"].ToString();
                            person.MothersSurname = dr["mothersSurname"].ToString();
                            person.BirthDate = Convert.ToDateTime(dr["birthDate"].ToString());
                            person.Gender = dr["gender"].ToString();
                            person.Phone = dr["phone"].ToString();
                            person.Email = dr["email"].ToString();
                            person.Address = dr["address"].ToString();
                            person.PersonId = dr["PersonID"].ToString() == "" ? 0 : Convert.ToInt32(dr["PersonID"]);
                            person.ConcurrencyPerson = (byte[])dr["concurrencyPerson"];
                            person.ClassPeople = new List<ClassPerson>
                            {
                                new()
                                {
                                    ClassId = Convert.ToByte(dr["ClassID"].ToString())
                                }
                            };
                            person.PositionPersonUnits = new List<PositionPersonUnit>
                            {
                                new()
                                {
                                    PositionId = Convert.ToByte(dr["PositionID"].ToString()),
                                    UnitId = Convert.ToByte(dr["UnitID"].ToString())
                                }
                            };
                            person.User = new User()
                            {
                                UserName = dr["userName"].ToString(),
                                Password = dr["password"].ToString(),
                                UserRols = new List<UserRol>
                                {
                                    new()
                                    {
                                        RolId = Convert.ToByte(dr["RolID"].ToString())
                                    }
                                }
                            };
                        }
                    }
                    Connection.CloseConnection();
                }
                return person;
            }
            catch (SqlException e)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<Person> GetParentById(int id)
    {
        Person person = new Person();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetParentById", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", id);
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        if (await dr.ReadAsync())
                        {
                            person.Id = Convert.ToInt32(dr["ID"]);
                            person.Dni = dr["DNI"].ToString();
                            person.FirstName = dr["firstname"].ToString();
                            person.FathersSurname = dr["fathersSurname"].ToString();
                            person.MothersSurname = dr["mothersSurname"].ToString();
                            person.BirthDate = Convert.ToDateTime(dr["birthDate"].ToString());
                            person.Gender = dr["gender"].ToString();
                            person.Phone = dr["phone"].ToString();
                            person.Email = dr["email"].ToString();
                            person.Address = dr["address"].ToString();
                            person.User = new User()
                            {
                                UserName = dr["userName"].ToString(),
                                Password = dr["password"].ToString(),
                                UserRols = new List<UserRol>
                                {
                                    new()
                                    {
                                        RolId = Convert.ToByte(dr["RolID"].ToString())
                                    }
                                }
                            };
                            person.ConcurrencyPerson = (byte[])dr["concurrencyPerson"];
                        }
                    }
                    Connection.CloseConnection();
                }
                return person;
            }
            catch (SqlException e)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetFathers()
    {
        var fatherList = new List<Person>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetFathers", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            fatherList.Add(new Person
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                FirstName = dr["firstName"].ToString(),
                                FathersSurname = dr["fathersSurname"].ToString(),
                                MothersSurname = dr["mothersSurname"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return fatherList;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetCounselors()
    {
        var counselorList = new List<Person>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetCounselors", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            counselorList.Add(new Person()
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
                                        }
                                    }
                                }
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return counselorList;
            }
            catch (SqlException e)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetInstructors()
    {
        var instructorList = new List<Person>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetInstructors", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            instructorList.Add(new Person()
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
                                }
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return instructorList;
            }
            catch (SqlException e)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }

    public async Task<IEnumerable<Person>> GetParents()
    {
        var parentList = new List<Person>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetParents", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            parentList.Add(new Person()
                            {
                                Id = Convert.ToInt32(dr["PeopleID"].ToString()),
                                Dni = dr["DNI"].ToString(),
                                FirstName = dr["firstName"].ToString(),
                                FathersSurname = dr["fathersSurname"].ToString(),
                                MothersSurname = dr["mothersSurname"].ToString(),
                                Phone = dr["phone"].ToString()
                            });
                        }
                    }
                    Connection.CloseConnection();
                }

                return parentList;
            }
            catch (SqlException e)
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
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}