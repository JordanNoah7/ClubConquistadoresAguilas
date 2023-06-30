using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class PersonRepository : ContextRepository, IGenericRepository<Person>
{
    public PersonRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<bool> Insert(Person model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.People.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }*/
    }

    public async Task<bool> Update(Person model)
    {
        throw new Exception();
        /*try
        {
            _dbContext.People.Update(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }*/
    }

    public async Task<bool> Delete(int id1, int id2 = 0)
    {
        throw new Exception();
        /*try
        {
            var model = _dbContext.People.First(p => p.Id.Equals(id1));
            _dbContext.People.Remove(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }*/
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
                            model.Club = new Club()
                            {
                                Id = Convert.ToInt16(reader["ClubID"])
                            };
                            model.PersonId = Convert.ToInt32(reader["PersonID"]);
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