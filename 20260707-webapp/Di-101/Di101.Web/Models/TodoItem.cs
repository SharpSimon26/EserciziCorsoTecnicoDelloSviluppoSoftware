namespace Di101.Web.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool Done { get; set; }
}