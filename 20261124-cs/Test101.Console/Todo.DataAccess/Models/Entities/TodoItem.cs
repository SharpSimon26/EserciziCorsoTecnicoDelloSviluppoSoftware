namespace Todo.DataAccess.Models.Entities;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; }
}
