using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTodo.Web.Models;
using WebAppTodo.Web.Services;

namespace WebAppTodo.Web.Pages;

public class IndexModel : PageModel
{
    public Todo[] Todos { get; set; } = [];

    public void OnGet()
    {
        Todos = TodoService.GetTodos();
    }
}
