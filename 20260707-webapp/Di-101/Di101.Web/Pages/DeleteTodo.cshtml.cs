using Di101.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Di101.Web.Pages;

public class DeleteModel : PageModel
{
    private readonly ITodoService _todoService;

    public DeleteModel(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        await _todoService.DeleteTodo(id);

        return RedirectToPage("Index");
    }
}
