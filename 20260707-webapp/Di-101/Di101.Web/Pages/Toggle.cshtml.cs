using Di101.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Di101.Web.Pages;

public class ToggleModel : PageModel
{
    private readonly ITodoService _todoService;

    public ToggleModel(ITodoService todoService)
    {
        _todoService = todoService;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var todo = await _todoService.GetTodoById(id) ?? 
            throw new Exception("ahia, qualcosa è andato storto...");

        todo.Done = !todo.Done;

        await _todoService.UpdateTodo(todo);

        return RedirectToPage("Index");
    }
}
