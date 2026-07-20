using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTodo.DataAccess.Models;

namespace WebAppTodo.Web.Pages;

public class IndexModel : PageModel
{
    public int TheAnswerOfUniverseAndEverything { get; } = 42;
    public List<Todo> Todos { get; private set; } = [];

    public void OnGet()
    {
        if (Todo.GetTodos().Count < 1)
        {
            var t1 = new Todo(1, "Fare la spesa", true);
            var t2 = new Todo(2, "Pagare le bollette");
            var t3 = new Todo(3, "Pisciare il cane");
            var t4 = new Todo(4, "Scendere la spazzatura");        
            Todo.GetTodos().AddRange(t1, t2, t3, t4);            
        }

        Todos = Todo.GetTodos();
    }

    public int Somma(int a, int b)
    {
        return a + b;
    }
}
