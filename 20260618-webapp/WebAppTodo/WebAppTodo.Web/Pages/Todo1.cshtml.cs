using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTodo.DataAccess.Models;
using WebAppTodo.DataAccess.Repositories;

namespace WebAppTodo.Web.Pages;

public class Todo1Model : PageModel
{
    private readonly ITodoRepository _todoRepository; 
    public IEnumerable<Todo> Todos { get; private set; } = [];

    public Todo1Model(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task OnGet()
    {
        Todos = await _todoRepository.GetTodos();
    }
}

