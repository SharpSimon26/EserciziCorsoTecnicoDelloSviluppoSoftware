using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.DataAccess.Repositories;
using TodoApp.Web.ExtensionMethods;

namespace TodoApp.Web.Pages;

public class ToggleModel : PageModel
{
    private readonly ITodoRepository _todoRepository;

    public ToggleModel(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var todo = await _todoRepository.GetTodoById(id);
        if (todo != null)
        {
            var affectedRows = await _todoRepository.UpdateTodo(todo.Id, todo.Description, !todo.Done);
            this.SetToast("Stato", affectedRows);
        }

        return RedirectToPage("Index");
    }
}