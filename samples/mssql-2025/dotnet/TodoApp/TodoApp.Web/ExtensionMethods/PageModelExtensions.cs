using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Web.Models;

namespace TodoApp.Web.ExtensionMethods;

public static class PageModelExtensions
{
    public static void SetToast(this PageModel page, string title, string message, OperationStatus status)
    {
        var toast = new ToastItem { Title = title, Message = message, Status = status, CreatedAt = DateTime.Now };
        page.TempData["ToastMessage"] = JsonSerializer.Serialize(toast);
    }

    public static void SetToast(this PageModel page, string title, string message, int affectedRows)
    {
        var status = affectedRows > 0 ? OperationStatus.Success : OperationStatus.Error;
        SetToast(page, title, message, status);
    }

    public static void SetToast(this PageModel page, string title, int affectedRows)
    {
        var message = affectedRows > 0 ? "Query Ok!" : "Qualcosa è andato storto...";
        SetToast(page, title, message, affectedRows);
    }
}