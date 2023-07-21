using System.Data;
using Domain;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;

namespace DataAccess;

public class CategoryRepository : ConnectionRepository, ICategoryRepository
{
    public CategoryRepository(IConfiguration configuration) : base(configuration)
    {
    }


    public async Task<IEnumerable<Category>> GetCategories()
    {
        var categoryList = new List<Category>();
        using (var cnDb = Connection.GetConnection(Configuration))
        {
            try
            {
                using (var cmd = new SqlCommand("usp_GetSpecialtyCategories", cnDb))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    Connection.OpenConnection();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                            categoryList.Add(new Category
                            {
                                Id = Convert.ToByte(dr["ID"].ToString()),
                                Name = dr["name"].ToString()
                            });
                    }

                    Connection.CloseConnection();
                }

                return categoryList;
            }
            catch (SqlException ex)
            {
                Connection.CloseConnection();
                return null;
            }
        }
    }
}