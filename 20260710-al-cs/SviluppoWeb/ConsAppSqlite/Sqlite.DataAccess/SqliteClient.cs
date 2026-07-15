using Microsoft.Data.Sqlite;
using Sqlite.DataAccess.Models;

namespace Sqlite.DataAccess;

public class SqliteClient
{
    private readonly SqliteConnection conn;

    public SqliteClient(string filename)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var dbPath = Path.Combine(baseDirectory, filename);
        var connection = new SqliteConnection($"Data Source={dbPath}");
        conn = connection;
    }

    public async Task<IEnumerable<Apple>> GetApples()
    {
        await conn.OpenAsync();

        var sql = @"select id, name, color from apples";

        using var cmd = new SqliteCommand(sql, conn);
        using var reader = await cmd.ExecuteReaderAsync();
        var apples = new List<Apple>();

        while (await reader.ReadAsync())
        {
            apples.Add(new Apple
            {
                Id = reader.GetInt64(reader.GetOrdinal("id")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                Color = reader.GetString(reader.GetOrdinal("color"))
            });
        }

        await conn.CloseAsync();

        return apples;
    }

    public async Task<long> Authenticate(string username, string password)
    {
        await conn.OpenAsync();

        // vulnerabile a sql injection
        // var sql = @$"select count(*) from users where username = '{username}' and password = '{password}'";

        // codice non vulnerabile perchè fa uso dei parametri
        var sql = @$"select count(*) from users where username = @username and password = @password";

        using var cmd = new SqliteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);

        var result = await cmd.ExecuteScalarAsync();
        var num = (result != null) ? (long)result : 0;

        await conn.CloseAsync();

        return num;
    }
}
