using ConsAppPokemonSpectre.Models;

namespace ConsAppPokemonSpectre.Extensions;

public static class PokemonExtensions
{
    /// <summary>
    /// Genera l'elenco dei Pokemon a partire dalla risposta API e aggiunge le opzioni di navigazione se presenti
    /// </summary>
    /// <param name="pokemonList">Risposta dell' API</param>
    /// <returns>Elenco con eventuali opzioni di navigazione per il menù</returns>
    public static List<IOperazione> ToOptionList(this PokeList pokemonList)
    {
        if (!pokemonList.Results.Any())
        {
            return [];
        }

        var pokemonChoices = new List<IOperazione>();

        if (pokemonList.Previous != null)
        {
            pokemonChoices.Add(new PokeOptionNav() { Name = "<- Precedente <-", Url = pokemonList.Previous });
        }

        pokemonChoices.AddRange(pokemonList.Results.Select(p => new PokeOptionItem(){ Name = p.Name, Url = p.Url }));

        if (pokemonList.Next != null)
        {
            pokemonChoices.Add(new PokeOptionNav() { Name = "-> Successivo ->", Url = pokemonList.Next });
        }

        return pokemonChoices;
    }
}