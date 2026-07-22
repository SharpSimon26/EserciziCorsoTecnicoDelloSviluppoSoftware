namespace TodoApp.Web.Models;

public class ToastItem
{
    public string Title { get; init; } = "Notifica";
    public string Message { get; init; } = string.Empty;
    public OperationStatus Status { get; init; }
    public DateTime CreatedAt { get; init; }
}
