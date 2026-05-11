using Spectre.Console;

var sceltaOperazione = await AnsiConsole.PromptAsync(
    new SelectionPrompt<string>()
        .Title("Seleziona l'operazione da effettuare:")
        .AddChoices("Somma", "Sottrazione", "Moltiplicazione", "Divisione"));

var v1 = await AnsiConsole.AskAsync<float>("Inserisci il primo numero: ");
var v2 = await AnsiConsole.AskAsync<float>("Inserisci il secondo numero: ");
var ris = 0f;

switch (sceltaOperazione)
{
    case "Somma":
        ris = v1 + v2;
        AnsiConsole.MarkupLine($"La somma tra [green]{v1}[/] e [green]{v2}[/] è [purple]{ris}[/]");
        break;
    case "Sottrazione":
        ris = v1 - v2;
        AnsiConsole.MarkupLine($"La sottrazione tra [green]{v1}[/] e [green]{v2}[/] è [purple]{ris}[/]");
        break;
    case "Moltiplicazione":
        ris = v1 * v2;
        AnsiConsole.MarkupLine($"La moltiplicazione tra [green]{v1}[/] e [green]{v2}[/] è [purple]{ris}[/]");
        break;
    case "Divisione":
        ris = v1 / v2;
        AnsiConsole.MarkupLine($"La divisione tra [green]{v1}[/] e [green]{v2}[/] è [purple]{ris}[/]");
        break;
    default:
        AnsiConsole.MarkupLine("[red]E' stata scelta un'ooerazione non supportata[/]");
        break;
}