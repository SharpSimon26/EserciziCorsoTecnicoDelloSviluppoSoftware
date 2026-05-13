using ConsAppTodo.Menu;
using ConsAppTodo.Models;
using Spectre.Console;

namespace ConsAppTodo.Extension;

public static class TodoExtensions
{
    private const string TXT_DONE = "[green]Completato[/]";
    private const string TXT_NOT_DONE = "[red]Non completato[/]";

    /// <summary>
    /// Genera il menù principale per il SelectionPrompt di Spectre
    /// </summary>
    /// <param name="todos"></param>
    /// <returns></returns>
    public static IEnumerable<Operazione> ToSpectreSelection(this IEnumerable<Todo> todos)
    {
        var selectionMenu = new List<Operazione>();

        // Elenco
        if (todos.Any())
        {
            var idPadding   = todos.OrderByDescending(p => p.Id)
                                   .FirstOrDefault()?
                                   .Id.ToString().Length ?? 1;
            var textPadding = todos.OrderByDescending(p => p.Text.Length)
                                   .FirstOrDefault()?
                                   .Text.Length ?? 1;

            selectionMenu.AddRange(todos.Select(t => new TodoMenuItem() 
            {
                ItemText = $"{t.Id.ToString().PadLeft(idPadding)} - {t.Text.PadRight(textPadding)} - {(t.Done ? TXT_DONE : TXT_NOT_DONE)}",
                ItemId = t.Id
            }));
        }

        // Nuovo
        selectionMenu.Add(new TodoMenuAdd());

        // Esci
        selectionMenu.Add(new TodoMenuExit());

        return selectionMenu;
    }

    public static Table ToSpectreTable(this Todo item)
    {
        var table = new Table().AddColumns("Id", "Testo", "Stato")
                               .AddRow(item.Id.ToString(), item.Text, item.Done ? TXT_DONE : TXT_NOT_DONE);

        return table;
    }

    public static IEnumerable<Operazione> ToSpectreSubSelection(this Todo todo)
    {
        var selectionMenu = new List<Operazione>()
        {
            new TodoMenuBack(), 
            new TodoMenuEdit() { ItemId = todo.Id }, 
            new TodoMenuCompleted() { ItemId = todo.Id, ItemText = todo.Done ? "Non completato" : "Completato" }, 
            new TodoMenuDelete() { ItemId = todo.Id }
        };

        return selectionMenu;
    }
}