using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;
using WebAppTodo.DataAccess.Models;

namespace WebAppTodo.DataAccess.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DbConnectionFactory _connectionFactory;
    private readonly ILogger<TodoRepository> _logger;

    public TodoRepository(DbConnectionFactory connectionFactory, ILogger<TodoRepository> logger)
    {
        _connectionFactory = connectionFactory;
        _logger = logger;
    }

    public async Task<IEnumerable<Todo>> GetTodos()
    {
        try
        {
            return await GetTodosInternal();
        }
        catch (OracleException ex) when (ex.Number == 12537)
        {
            _logger.LogWarning(ex, "Connessione Oracle non valida. Riprovo una volta...");

            return await GetTodosInternal();
        }
        catch (OracleException oex)
        {
            _logger.LogError(oex, "Errore durante la connessione al database");

            return [];
        }
    }

    private async Task<IEnumerable<Todo>> GetTodosInternal()
    {
        using OracleConnection con = _connectionFactory.CreateConnection();
        await con.OpenAsync();

        using OracleCommand cmd = con.CreateCommand();
        cmd.CommandText = "select id, description, done from todos";

        using OracleDataReader reader = await cmd.ExecuteReaderAsync();
        List<Todo> todos = [];

        while (await reader.ReadAsync())
        {
            todos.Add(new Todo(
                id: reader.GetInt32(reader.GetOrdinal("id")),
                description: reader.GetString(reader.GetOrdinal("description")),
                done: reader.GetBoolean(reader.GetOrdinal("done"))
            ));
        }
        
        return todos;
    }
}
