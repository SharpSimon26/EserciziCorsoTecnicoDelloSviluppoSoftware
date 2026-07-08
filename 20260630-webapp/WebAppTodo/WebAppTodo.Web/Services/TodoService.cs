using WebAppTodo.Web.Models;

namespace WebAppTodo.Web.Services;

public static class TodoService
{
    private static Todo[] _todos =
    [
        new Todo() { Id = 1, Text = "fare la spesa", Done = false },
        new Todo() { Id = 2, Text = "andare a Bologna", Done = true },
        new Todo() { Id = 3, Text = "fare il bagno a Barcola", Done = false }        
    ];

    public static Todo[] GetTodos()
    {
        return _todos;
    }

    public static Todo? GetTodoById(int id)
    {
        return _todos.FirstOrDefault(m => m.Id == id);
    }

    public static void CreateTodo(string text, bool done = false)
    {
        var newId = _todos.OrderByDescending(m => m.Id)
                         .FirstOrDefault()?.Id +1 ?? 1;
        var newTodo = new Todo() { Id = newId, Text = text, Done = done };

        Array.Resize(ref _todos, _todos.Count()+1);
        _todos[_todos.Length -1] = newTodo;
    }

    public static void UpdateTodo(int id, string text, bool done)
    {
        var todo = GetTodoById(id);
        if (todo != null)
        {
            todo.Text = text;
            todo.Done = done;
        }
    }

    public static void DeleteTodo(int id)
    {
    }
}