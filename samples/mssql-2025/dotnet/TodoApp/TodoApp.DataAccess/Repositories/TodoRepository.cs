using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Repositories;

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
            using IDbConnection db = _connectionFactory.CreateConnection();
            var sql = "select id, description, done from todos";
            var todos = await db.QueryAsync<Todo>(sql);
            _logger.LogInformation("{0} Todo", todos.Count());

            return todos;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la query sul database");

            return [];
        }
    }

    public async Task<Todo?> GetTodoById(int id)
    {
        try
        {
            using IDbConnection db = _connectionFactory.CreateConnection();
            var sql = "select id, description, done from todos where id = @id";
            var data = new { id = id };
            var todo = await db.QueryFirstOrDefaultAsync<Todo>(sql, data);

            return todo;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la query sul database");

            return null;
        }
    }

    public async Task<int> AddTodo(string description)
    {
        try
        {
            using IDbConnection db = _connectionFactory.CreateConnection();
            var sql = "insert into todos (description) values (@description)";
            var data = new { description = description };
            var affectedRows = await db.ExecuteAsync(sql, data);
            _logger.LogInformation("Add Todo {0} righe", affectedRows);

            return affectedRows;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'inserimento sul database");

            return -1;
        }
    }

    public async Task<int> UpdateTodo(int id, string description, bool done)
    {
        try
        {
            using IDbConnection db = _connectionFactory.CreateConnection();
            var sql = "update todos set description = @description, done = @done where id = @id";
            var data = new { id = id, description = description, done = done };
            var affectedRows = await db.ExecuteAsync(sql, data);
            _logger.LogInformation("Update Todo {0} righe", affectedRows);

            return affectedRows;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante l'aggiornamento sul database");

            return -1;
        }
    }

    public async Task<int> DeleteTodoById(int id)
    {
        try
        {
            using IDbConnection db = _connectionFactory.CreateConnection();
            var sql = "delete from todos where id = @id";
            var data = new { id = id };
            var affectedRows = await db.ExecuteAsync(sql, data);
            _logger.LogInformation("Delete Todo {0} righe", affectedRows);

            return affectedRows;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Errore durante la cancellazione sul database");

            return -1;
        }
    }
}