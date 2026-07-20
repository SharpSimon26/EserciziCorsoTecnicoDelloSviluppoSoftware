namespace WebAppTodo.DataAccess.Models;

public class Todo
{
    public Todo(int id, string description, bool done = false)
    {
        Id = id;
        Description = description;
        Done = done;
    }

    public int Id { get; set; }

    public string Description { get; set; }

    public bool Done { get; set; }


    private static readonly List<Todo> todos = [];
    
    public static List<Todo> GetTodos()
    {
        return todos;
    }
}