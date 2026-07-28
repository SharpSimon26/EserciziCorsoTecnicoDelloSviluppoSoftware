namespace Db101.MSSQL.Console;

public class Todo
{
    public int Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public bool Done { get; init; }
}