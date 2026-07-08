using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTodo.Web.Models;
using WebAppTodo.Web.Services;

namespace WebAppTodo.Web.Pages;

public class DettaglioModel : PageModel
{
    public Todo todo { get; set; }

    public IActionResult OnGet(int id)
    {
        var t = TodoService.GetTodoById(id);

        if (t != null)
        {
            todo = t;
        }
        else
        {
            return RedirectToPage("/Index");
        }

        return Page();
    }
}
