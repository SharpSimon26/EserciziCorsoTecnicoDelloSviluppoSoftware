using Todo.DataAccess.Database;
using Todo.DataAccess.Models.Entities;
using Dapper;
using Todo.DataAccess.DTO;

namespace Todo.DataAccess.Repositories;

public class TodoRepository : AbstractRepository, ITodoRepository
{
    public TodoRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "select * from todos order by Id";
        var todos = await conn.QueryAsync<TodoItem>(sql);

        return todos;
    }

    public async Task<TodoItem?> GetTodoByIdAsync(int id)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "select * from todos where Id = @id";
        var todo = await conn.QueryFirstOrDefaultAsync<TodoItem>(sql, new { id });

        return todo;
    }

    public async Task<TodoItem?> CreateTodoAsync(TodoCreateDTO dto)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = @"
            insert into todos (Description, Done) values (@Description, @Done);
            select id, description, done from todos where id = @@IDENTITY;
        ";
        var todo = await conn.QueryFirstOrDefaultAsync<TodoItem>(sql, new { dto.Description, Done = false });

        return todo;
    }

    public async Task<TodoItem?> UpdateTodoAsync(TodoUpdateDTO dto)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = @"
            update todos set Description = @Description, Done = @Done where Id = @Id;
            select id, description, done from todos where id = @Id;
        ";
        var todo = await conn.QueryFirstOrDefaultAsync<TodoItem>(sql, new { dto.Id, dto.Description, dto.Done });

        return todo;
    }

    public async Task<TodoItem?> ChangeTodoAsync(TodoChangeDTO dto)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = @"
            update todos set done = @Done where id = @Id
            select id, description, done from todos where id = @Id;
        ";
        var todo = await conn.QueryFirstOrDefaultAsync<TodoItem>(sql, new { dto.Id, dto.Done });

        return todo;
    }    

    public async Task<bool> DeleteTodoByIdAsync(int id)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "delete from todos where id = @id";
        var todo = await conn.ExecuteAsync(sql, new { id });

        return todo > 0;
    }
}

