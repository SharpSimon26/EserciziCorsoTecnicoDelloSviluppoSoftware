using WebAppTodo.DataAccess.Models;

namespace WebAppTodo.Web.Services;

public interface ITodoService
{
    int AddTodo(string description, bool done);
    IEnumerable<Todo> GetTodos();
    bool UpdateTodoById(int id, bool done);
    bool UpdateTodoById(int id, string description, bool done);
    bool DeleteTodoById(int id);
}