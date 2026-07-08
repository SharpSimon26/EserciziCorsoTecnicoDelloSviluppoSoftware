using Di101.Web.Models;

namespace Di101.Web.Services;

public class TodoService : ITodoService
{
    private List<TodoItem> _todos { get; set; } = [];

    public TodoService()
    {
        AddTodo("fare la spesa");
        AddTodo("studiare C#");
        AddTodo("fare un toc'");
    }

    public List<TodoItem> GetTodos()
    {
        return _todos;
    }

    public async Task<TodoItem?> GetTodoById(int id)
    {
        return _todos.SingleOrDefault(t => t.Id == id);
    }

    public void AddTodo(string text)
    {
        var lastId = 0;

        if (_todos.Count > 0)
        {
            lastId = _todos.Max(m => m.Id);
        }
    
        var newTodoItem = new TodoItem
        {
            Id = lastId + 1,
            Text = text,
            Done = false
        };

        _todos.Add(newTodoItem);
    }

    public async Task ToggleTodo(int id)
    {
        var todo = await GetTodoById(id) ?? 
            throw new Exception("ahia, qualcosa è andato storto...");

        todo.Done = !todo.Done;

        await UpdateTodo(todo);
    }

    public async Task UpdateTodo(int id, string text)
    {
        int index = _todos.FindIndex(t => t.Id == id);

        if(index >= 0)
        {
            _todos[index].Text = text;
        }
    }

    public async Task UpdateTodo(TodoItem todo)
    {
        int index = _todos.FindIndex(t => t.Id == todo.Id);

        if(index >= 0)
        {
            _todos[index] = todo;
        }
    }

    public async Task DeleteTodo(int id)
    {
        int index = _todos.FindIndex(t => t.Id == id);

        if(index >= 0)
        {
            _todos.RemoveAt(index);
        }
    }
}