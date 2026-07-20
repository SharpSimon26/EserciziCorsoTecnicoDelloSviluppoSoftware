using WebAppTodo.DataAccess.Models;

namespace WebAppTodo.DataAccess.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<Todo>> GetTodos();
}