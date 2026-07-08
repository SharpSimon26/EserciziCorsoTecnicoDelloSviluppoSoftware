using Di101.Web.Models;

namespace Di101.Web.Services;

public interface ITodoService
{
    List<TodoItem> GetTodos();
    Task<TodoItem?> GetTodoById(int id);
    void AddTodo(string text);
    Task ToggleTodo(int id);
    Task UpdateTodo(int id, string text);
    Task UpdateTodo(TodoItem todo);
    Task DeleteTodo(int id);
}