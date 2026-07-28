using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess;

public class DbConnectionFactory : IAsyncDisposable
{
    private readonly string _connectionString;
    private SqlConnection? _connection;

    public DbConnectionFactory(IConfiguration config)
    {
        var dbSettings = config.GetRequiredSection("MSSqlDbSettings").Get<MSSqlDbSettings>() ??
                         throw new InvalidOperationException("Impossibile trovare i dati per l'accesso al database");

        _connectionString = $"Server={dbSettings.Server};Database={dbSettings.Database};User Id={dbSettings.Username};Password={dbSettings.Password};TrustServerCertificate=True";
    }

    public async Task<IDbConnection> CreateConnection()
    {
        if (_connection == null)
        {
            _connection = new SqlConnection(_connectionString);
            await _connection.OpenAsync();

            return _connection;
        }
        else
        {
            return _connection;
        }   
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            await _connection.CloseAsync();
        }
    }
}