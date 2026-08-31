using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace JsonPlaceholder.DataAccess.Database;

public class DbConnectionFactory : IAsyncDisposable
{
    private readonly string _connectionString;
    private SqlConnection? _connection;

    public DbConnectionFactory(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection") ??
                            throw new InvalidOperationException("Impossibile accedere al database");
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
