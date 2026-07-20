namespace WebAppTodo.DataAccess.Models;

public class OracleDbSettings
{
    public string Host { get; init; } = string.Empty;
    public int Port { get; init; }
    public string ServiceName { get; init; } = string.Empty;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}