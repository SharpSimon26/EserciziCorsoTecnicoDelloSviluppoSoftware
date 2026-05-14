using ConsAppTodo.Models;

namespace ConsAppTodo.Services;

public class TodoService
{
    private readonly List<Todo> _todos;
    private int newId;

    public TodoService()
    {
        _todos = [];
        newId = 1;
    }

    public IEnumerable<Todo> GetAll()
    {
        return _todos.Select(m => new Todo()
        {
            Id = m.Id,
            Text = m.Text,
            Done = m.Done
        });
    }

    public Todo? GetById(int id)
    {
        var todo = _todos.FirstOrDefault(m => m.Id == id);
        if (todo == null) return null;

        return new Todo()
        {
            Id = todo.Id,
            Text = todo.Text,
            Done = todo.Done
        };
    }

    public int Add(string testo, bool done = false)
    {
        var newTodo = new Todo()
        { 
            Id = newId, 
            Text = testo, 
            Done = done
        };

        _todos.Add(newTodo);
        newId++;
    
        return newTodo.Id;
    }

    public bool Update(int id, string testo, bool done)
    {
        var todoIndex = _todos.FindIndex(m => m.Id == id);
        if (todoIndex > -1)
        {
            _todos[todoIndex].Text = testo;
            _todos[todoIndex].Done = done;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        var num = _todos.RemoveAll(m => m.Id == id);
        return num > 0;
    }
}