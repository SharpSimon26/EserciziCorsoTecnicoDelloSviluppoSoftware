using ConsAppSpectreSelection3;
using Spectre.Console;

var sceltaOperazione = await AnsiConsole.PromptAsync(
    new SelectionPrompt<IOperazione>()
        .Title("Seleziona l'operazione da effettuare:")
        .AddChoices(
            new Somma(),
            new Sottrazione(),
            new Moltiplicazione(),
            new Divisione()
        )
        .UseConverter(o => o.GetOperazione()));

var v1 = await AnsiConsole.AskAsync<float>("Inserisci il primo numero: ");
var v2 = await AnsiConsole.AskAsync<float>("Inserisci il secondo numero: ");
var ris = sceltaOperazione.Processa(v1, v2);

AnsiConsole.MarkupLine($"Il risultato della [red]{sceltaOperazione.GetOperazione()}[/] di [green]{v1}[/] e [green]{v2}[/] è [purple]{ris}[/]");
