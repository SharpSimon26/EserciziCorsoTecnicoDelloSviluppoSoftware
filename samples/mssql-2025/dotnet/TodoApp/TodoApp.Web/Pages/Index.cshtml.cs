using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.DataAccess.Models;
using TodoApp.DataAccess.Repositories;

namespace TodoApp.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ITodoRepository _todoRepository;
    public IEnumerable<Todo> Todos { get; set; }

    public IndexModel(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
        Todos = [];
    }

    public async Task OnGet()
    {
        var todos = await _todoRepository.GetTodos();
        Todos = todos;
    }
}
