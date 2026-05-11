using Spectre.Console;

/*
var fileName = await AnsiConsole.PromptAsync<string>(
    new TextPrompt<string>("Inserisci il nome del file: ")
    .DefaultValue("noname000")
    .ShowDefaultValue());
*/

// https://spectreconsole.net/console/prompts/selection-prompt
var fruit = await AnsiConsole.PromptAsync(
    new SelectionPrompt<string>()
        .Title("Qual è il tuo frutto preferito?")
        .AddChoices("Apple", "Banana", "Orange", "Mango", "Strawberry"));
  
AnsiConsole.MarkupLine($"Hai selezionato: [green]{fruit}[/]");
