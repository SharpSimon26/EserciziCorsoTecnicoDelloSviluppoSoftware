using Sqlite.DataAccess;
using Spectre.Console;

var sqlite = new SqliteClient("sample.db");

var username = await AnsiConsole.AskAsync<string>("[green]Username:[/] ");
var password = await AnsiConsole.PromptAsync(new TextPrompt<string>("[green]Password:[/] "));

var a = await sqlite.Authenticate(username, password);

if (a > 0)
{
    AnsiConsole.MarkupLine($"\nBenvenuto [yellow]{username}[/]");
}
else
{
    AnsiConsole.MarkupLine($"\n[red]Accesso non consentito[/]");
}

/*
*** SQL Injection ***
Username: paperino
Password: ' OR '' = ' 

Benvenuto paperino
*/