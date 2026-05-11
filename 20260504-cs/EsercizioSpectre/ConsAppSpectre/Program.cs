using Spectre.Console;

// Color cl = Console.ForegroundColor;
// Console.ForegroundColor = ConsoleColor.Red;
// AnsiConsole.MarkupLine("[red]Ciao a tutti[/]");

int v1 = await AnsiConsole.AskAsync<int>("Inserisci il primo numero: ");
int v2 = await AnsiConsole.AskAsync<int>("Inserisci il secondo numero: ");

int ris = v1 + v2;

AnsiConsole.MarkupLine($"La somma tra [green]{v1}[/] e [green]{v2}[/] è [purple]{ris}[/]");
