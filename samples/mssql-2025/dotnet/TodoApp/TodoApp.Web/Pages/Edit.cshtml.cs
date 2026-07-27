using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.DataAccess.Repositories;
using TodoApp.Web.ExtensionMethods;
using TodoApp.Web.Forms;

namespace TodoApp.Web.Pages;

public class EditModel : PageModel
{
    private readonly ITodoRepository _todoRepository;

    [BindProperty]
    public TodoForm TodoForm { get; set; } = new();

    public EditModel(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var todo = await _todoRepository.GetTodoById(id);

        if (todo != null)
        {
            var todoForm = new TodoForm
            {
                Id = todo.Id,
                Description = todo.Description,
                Done = todo.Done
            };

            TodoForm = todoForm;

            return Page();
        }
        else
        {
            return RedirectToPage("Index");
        }
    }

    public async Task<IActionResult> OnPost(TodoForm todoForm)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var affectedRows = await _todoRepository.UpdateTodo(todoForm.Id, todoForm.Description, todoForm.Done);
        this.SetToast("Modifica", affectedRows);

        return RedirectToPage("Index");
    }
}