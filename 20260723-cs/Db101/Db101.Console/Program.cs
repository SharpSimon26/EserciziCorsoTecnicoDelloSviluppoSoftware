using Microsoft.Data.Sqlite;
using Dapper;
using Db101.Console;


var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
var dbPath = Path.Combine(baseDirectory, "sample.db");
using SqliteConnection db = new($"DataSource={dbPath}");
await db.OpenAsync();

var sql = "select id, name, color from apples";
var apples = await db.QueryAsync<Apple>(sql);

if (apples.Any())
{
    foreach (var apple in apples)
    {
        Console.WriteLine(apple.Name);
    }
}

