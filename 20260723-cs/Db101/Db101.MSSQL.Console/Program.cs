using Microsoft.Data.SqlClient;
using Dapper;
using Db101.MSSQL.Console;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<MSSqlDbSettings>()
            .AddEnvironmentVariables();

IConfiguration configuration = builder.Build();

//var conn = "Server(localdb)\\MSSQLLocalDB;Database=primodb;Integrated Security=true";
//var conn = new SqlConnection($"Server={};Database=TodoDatabase;User Id=sa;Password=athosathos123!;TrustServerCertificate=True");
await using var conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

await conn.OpenAsync();

var sql = "select Id, Description, Done from Todos";
var todos = await conn.QueryAsync<Todo>(sql);

if (todos.Any())
{
    foreach (var todo in todos)
    {
        Console.WriteLine(todo.Id + " - " + todo.Description + " - " + (todo.Done ? "Ok" : "No"));
    }
}
