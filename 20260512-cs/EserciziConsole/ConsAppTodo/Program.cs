using ConsAppTodo.Menu;
using ConsAppTodo.Extension;
using ConsAppTodo.Services;
using Spectre.Console;

var todoService = new TodoService();

todoService.Add("Comprare il latte");
todoService.Add("Pisciare il cane");
todoService.Add("Andare a Barcola");

IEnumerable<Operazione> todos;
Console.Clear();

while (true)
{
    todos = todoService.GetAll().ToSpectreSelection();

    var selectedOption = await AnsiConsole.PromptAsync(
        new SelectionPrompt<Operazione>()
            .Title("Cose da fare")
            .MoreChoicesText("Move up and down to see more todos")
            .HighlightStyle(new Style(Color.Cyan1, decoration: Decoration.Bold))
            .AddChoices(todos)
            .UseConverter(p => p.ItemText)
    );

    if (selectedOption is TodoMenuItem menuItem)
    {
        // read - back - update txt - update status - delete
        var selectedTodo = todoService.GetById(menuItem.ItemId);

        if (selectedTodo != null)
        {
            AnsiConsole.Write(selectedTodo.ToSpectreTable());

            var todoAction = await AnsiConsole.PromptAsync(
                new SelectionPrompt<Operazione>()
                    .Title("Azione")
                    .AddChoices(selectedTodo.ToSpectreSubSelection())
                    .UseConverter(p => p.ItemText));

            if (todoAction is TodoMenuEdit)
            {
                var editItemText = await AnsiConsole.AskAsync<string>("Modifica il testo: ", selectedTodo.Text);
                todoService.Update(selectedTodo.Id, editItemText, selectedTodo.Done);
            }
            else if (todoAction is TodoMenuCompleted)
            {
                todoService.Update(selectedTodo.Id, selectedTodo.Text, !selectedTodo.Done);
            }
            else if (todoAction is TodoMenuDelete)
            {
                todoService.Delete(selectedTodo.Id);
            }

            Console.Clear();         
        }
    }
    else if (selectedOption is TodoMenuAdd)
    {
        // add
        var newItemText = await AnsiConsole.AskAsync<string>("Inserisci il testo: ");
        todoService.Add(newItemText);
        Console.Clear();
    }
    else if (selectedOption is TodoMenuExit)
    {
        break;
    }
}
