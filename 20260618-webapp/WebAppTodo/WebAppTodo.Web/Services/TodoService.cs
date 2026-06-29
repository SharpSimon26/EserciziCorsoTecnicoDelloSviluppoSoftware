using WebAppTodo.DataAccess.Models;

namespace WebAppTodo.Web.Services;

public class TodoService : ITodoService
{
    private readonly List<Todo> _todos = [];

    public int AddTodo(string description, bool done)
    {
        var newId = _todos.Max(m => m.Id) + 1;
        var newTodo = new Todo(newId, description, done);
        _todos.Add(newTodo);

        return newId;
    }

    public IEnumerable<Todo> GetTodos()
    {
        var todos = _todos.Select(m => new Todo(m.Id, m.Description, m.Done));

        return todos;
    }    

    public bool UpdateTodoById(int id, bool done)
    {
        var todo = _todos.FirstOrDefault(m => m.Id == id);
        
        if (todo != null)
        {
            todo.Done = done;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateTodoById(int id, string description, bool done)
    {
        var todo = _todos.FirstOrDefault(m => m.Id == id);

        if (todo != null)
        {
            todo.Description = description;
            todo.Done = done;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteTodoById(int id)
    {
        var todo = _todos.FirstOrDefault(m => m.Id == id);

        if (todo != null)
        {
            _todos.Remove(todo);

            return true;
        }
        else
        {
            return false;
        }
    }
}