using ConsAppPokemonSpectre.Models;
using Spectre.Console;

namespace ConsAppPokemonSpectre.Extensions;

public static class PokemonExtensions
{
    /// <summary>
    /// Genera l'elenco dei Pokemon a partire dalla risposta API e aggiunge le opzioni di navigazione se presenti
    /// </summary>
    /// <param name="pokemonList">Risposta dell' API</param>
    /// <returns>Elenco con eventuali opzioni di navigazione per il menù</returns>
    public static List<Operazione> ToOptionList(this PokeList pokemonList)
    {
        if (!pokemonList.Results.Any())
        {
            return [];
        }

        var pokemonChoices = new List<Operazione>();

        if (pokemonList.Previous != null)
        {
            pokemonChoices.Add(new PokeOptionNav() { Name = "<- Precedente <-", Url = pokemonList.Previous });
        }

        pokemonChoices.AddRange(pokemonList.Results.Select(p => new PokeOptionItem(){ Name = p.Name.UcFirst(), Url = p.Url }));

        if (pokemonList.Next != null)
        {
            pokemonChoices.Add(new PokeOptionNav() { Name = "-> Successivo ->", Url = pokemonList.Next });
        }

        pokemonChoices.Add(new PokeOptionExit() { Name = "----- Esci -----" });

        return pokemonChoices;
    }

    /// <summary>
    /// Converte l'oggetto in una tabella per visualizzare i dati
    /// </summary>
    /// <param name="pokemon"></param>
    /// <returns></returns>
    public static Table ToTable(this Pokemon pokemon)
    {
        var table = new Table();
        table.AddColumns("Id", "Name", "Height", "Weight");
        table.AddRow(pokemon.Id.ToString(), pokemon.Name.UcFirst(), pokemon.Height.ToString(), pokemon.Weight.ToString());

        return table;
    }
}