using ConsAppTodo.Models;

namespace ConsAppTodo.Services;

public class TodoService
{
    private readonly List<Todo> todos;

    public TodoService()
    {
        todos = [];
    }

    public IEnumerable<Todo> GetAll()
    {
        return todos;
    }

    public Todo? GetById(int id)
    {
        return todos.FirstOrDefault(m => m.Id == id);
    }

    public Todo Add(string testo, bool done = false)
    {
        var newId = todos.OrderByDescending(m => m.Id).FirstOrDefault()?.Id + 1 ?? 1;
        var newTodo = new Todo(){ Id = newId, Text = testo, Done = done };
        todos.Add(newTodo);
    
        return newTodo;
    }

    public bool Update(int id, string testo, bool done)
    {
        var todoIndex = todos.FindIndex(m => m.Id == id);
        if (todoIndex > -1)
        {
            todos[todoIndex].Text = testo;
            todos[todoIndex].Done = done;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        var num = todos.RemoveAll(m => m.Id == id);
        return num > 0;
    }
}