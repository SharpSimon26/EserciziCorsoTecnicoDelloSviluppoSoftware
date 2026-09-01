using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Todo.DataAccess.Database;

public class DbConnectionFactory : IDbConnectionFactory, IAsyncDisposable
{
    private readonly string _connectionString;
    private SqlConnection? _connection;
    private readonly ILogger<DbConnectionFactory> _logger;

    public DbConnectionFactory(IConfiguration config, ILogger<DbConnectionFactory> logger)
    {
        _connectionString = config.GetConnectionString("DefaultConnection") ??
                            throw new InvalidOperationException("Impossibile accedere al database");
        _logger = logger;
    }

    public async Task<IDbConnection> CreateConnection()
    {
        if (_connection == null)
        {
            _connection = new SqlConnection(_connectionString);
            await _connection.OpenAsync();
            _logger.LogInformation("New Connection!");

            return _connection;
        }
        else
        {
            _logger.LogInformation("Using saved connection...");

            return _connection;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection != null)
        {
            _logger.LogInformation("Closing connection...");

            await _connection.CloseAsync();
        }
    }
}
