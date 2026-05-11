using ConsAppPokemonSpectre.Clients;
using ConsAppPokemonSpectre.Extensions;
using ConsAppPokemonSpectre.Models;
using Spectre.Console;

var pokemonList = await PokemonClient.GetPokemonListAsync();
var pokemonChoices = new List<IOperazione>();

while (true)
{
    if (pokemonList == null)
    {
        Console.WriteLine("Non ho trovato nessun Pokemon");

        break;
    }

    pokemonChoices = pokemonList.ToOptionList();

    var selectedOption = await AnsiConsole.PromptAsync(
        new SelectionPrompt<IOperazione>()
            .Title("Scegli il Pokemon")
            .MoreChoicesText("[grey](Move up and down to see more pokemons)[/]")
            .HighlightStyle(new Style(Color.Cyan1, decoration: Decoration.Bold))
            .AddChoices(pokemonChoices)
            .UseConverter(p => p.Name.UcFirst())
    );

    if (selectedOption is PokeOptionNav)
    {
        pokemonList = await PokemonClient.GetPokemonListAsync(selectedOption.Url);   
    }
    else
    {
        var pokemon = await PokemonClient.GetPokemonByUrlAsync(selectedOption.Url);

        if (pokemon != null)
        {
            Console.WriteLine("Id: {0} - Name: {1} - Height: {2} - Weight: {3} - Base Experience: {4}", 
                pokemon.Id, pokemon.Name.UcFirst(), pokemon.Height, pokemon.Weight, pokemon.BaseExperience);            
        }
        else
        {
            Console.WriteLine("Si è verificato un errore (Pokemon is null)");
        }

        break;
    }    
}
