using System.Data;
using Microsoft.Data.SqlClient;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess;

public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(MSSqlDbSettings dbSettings)
    {
        _connectionString = $"Server={dbSettings.Server};Database={dbSettings.Database};User Id={dbSettings.Username};Password={dbSettings.Password};TrustServerCertificate=True";
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}