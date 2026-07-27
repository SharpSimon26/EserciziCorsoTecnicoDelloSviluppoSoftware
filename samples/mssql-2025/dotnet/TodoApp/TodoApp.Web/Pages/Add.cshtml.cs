using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.DataAccess.Repositories;
using TodoApp.Web.ExtensionMethods;
using TodoApp.Web.Forms;

namespace TodoApp.Web.Pages;

public class AddModel : PageModel
{
    private readonly ITodoRepository _todoRepository;

    [BindProperty]
    public TodoForm TodoForm { get; set; } = new();

    public AddModel(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IActionResult> OnPost(TodoForm todoForm)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var affectedRows = await _todoRepository.AddTodo(todoForm.Description);
        this.SetToast("Nuovo", affectedRows);

        return RedirectToPage("Index");

    }
}