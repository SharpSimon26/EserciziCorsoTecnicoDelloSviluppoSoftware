using ConsAppPokemonSpectre.Clients;
using ConsAppPokemonSpectre.Extensions;
using ConsAppPokemonSpectre.Models;
using Spectre.Console;

using var pokemonClient = new PokemonClient();
var pokemonList = await pokemonClient.GetPokemonListAsync();
var pokemonChoices = new List<Operazione>();

while (true)
{
    if (pokemonList == null)
    {
        Console.WriteLine("Non ho trovato nessun Pokemon");

        break;
    }

    pokemonChoices = pokemonList.ToOptionList();

    var selectedOption = await AnsiConsole.PromptAsync(
        new SelectionPrompt<Operazione>()
            .Title("Scegli il Pokemon")
            .MoreChoicesText("[grey](Move up and down to see more pokemons)[/]")
            .HighlightStyle(new Style(Color.Cyan1, decoration: Decoration.Bold))
            .AddChoices(pokemonChoices)
            .UseConverter(p => p.Name)
    );

    if (selectedOption is PokeOptionNav)
    {
        pokemonList = await pokemonClient.GetPokemonListAsync(selectedOption.Url);   
    }
    else
    {
        var pokemon = await pokemonClient.GetPokemonByUrlAsync(selectedOption.Url);

        if (pokemon != null)
        {
            AnsiConsole.MarkupLine("Id: [cyan]{0}[/] - Name: [cyan]{1}[/] - Height: [cyan]{2}[/] - Weight: [cyan]{3}[/] - Base Experience: [cyan]{4}[/]", 
                pokemon.Id, pokemon.Name.UcFirst(), pokemon.Height, pokemon.Weight, pokemon.BaseExperience);            
        }
        else
        {
            Console.WriteLine("Si è verificato un errore (Pokemon is null)");
        }

        break;
    }    
}
