namespace TodoApp.DataAccess.Models;

public class Todo
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool Done { get; set; }
}