using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class Connection
{
    private static Connection cn = new();
    private static readonly object LockObject = new();
    private static SqlConnection? _connection;
    private static string? _connectionString;

    private Connection()
    {
    }

    public static SqlConnection GetConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connection");
        if (_connection == null)
            lock (LockObject)
            {
                if (_connection == null) _connection = new SqlConnection(_connectionString);
            }

        return _connection;
    }

    public static void OpenConnection()
    {
        if (_connection != null) _connection.Open();
    }

    public static void CloseConnection()
    {
        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
            _connection = null;
        }
    }
}