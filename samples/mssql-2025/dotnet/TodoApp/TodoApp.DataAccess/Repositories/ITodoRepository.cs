using TodoApp.DataAccess.Models;

namespace TodoApp.DataAccess.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetTodos();
    Task<Todo?> GetTodoById(int id);
    Task<int> AddTodo(string description);
    Task<int> UpdateTodo(int id, string description, bool done);
    Task<int> DeleteTodoById(int id);
}