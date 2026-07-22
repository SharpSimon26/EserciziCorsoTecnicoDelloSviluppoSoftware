using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.DataAccess.Repositories;
using TodoApp.Web.ExtensionMethods;

namespace TodoApp.Web.Pages;

public class DeleteModel : PageModel
{
    private readonly ITodoRepository _todoRepository;

    public DeleteModel(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var todo = await _todoRepository.GetTodoById(id);
        if (todo != null)
        {
            var affectedRows = await _todoRepository.DeleteTodoById(todo.Id);
            this.SetToast("Elimina", affectedRows);
        }

        return RedirectToPage("Index");
    }
}