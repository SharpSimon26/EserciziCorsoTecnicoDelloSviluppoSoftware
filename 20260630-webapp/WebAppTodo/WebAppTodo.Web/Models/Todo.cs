namespace WebAppTodo.Web.Models;

public class Todo
{
    public int Id { get; set; }

    public required string Text { get; set; }

    public bool Done { get; set; }
}
