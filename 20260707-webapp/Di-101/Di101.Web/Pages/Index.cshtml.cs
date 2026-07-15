using Di101.Web.Models;
using Di101.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Di101.Web.Pages;

public class IndexModel : PageModel
{
    public CounterService Counter { get; set; }
    public CounterService Counter2 { get; set; }
    private readonly ITodoService _todoService;
    public List<TodoItem> Todos { get; set; } = [];

    [BindProperty]
    public TodoForm TodoForm { get; set; } = new();

    public IndexModel(CounterService counter, TestService test, ITodoService todoService)
    {
        Counter = counter;
        Counter2 = test.Counter;
        _todoService = todoService;
    }

    public async Task<IActionResult> OnGet(string? action, int? id)
    {
        if (!string.IsNullOrWhiteSpace(action) && id != null)
        {
            switch(action)
            {
                case "toggle":
                    await _todoService.ToggleTodo(id.Value);
                    break;

                case "edit":
                    var todoItem = await _todoService.GetTodoById(id.Value);

                    if (todoItem != null)
                    {
                        TodoForm = new TodoForm { Id = todoItem.Id, Text = todoItem.Text, Done = todoItem.Done };
                    }
                    else
                    {
                        return NotFound();
                    }
                    
                    break;

                case "delete":
                    await _todoService.DeleteTodo(id.Value);
                    break;
                    
                default:
                    break;
            }
        }

        Todos = _todoService.GetTodos();

        return Page();
    }

    public async Task<IActionResult> OnPost(TodoForm todoForm)
    {
        if (ModelState.IsValid)
        {
            if (todoForm.Id == 0)
            {
                _todoService.AddTodo(todoForm.Text);
            }
            else
            {
                await _todoService.UpdateTodo(todoForm.Id, todoForm.Text, todoForm.Done);
            }
        }

        return RedirectToPage("Index");  
    }
}
