namespace WebAppTodo.Web.Services;

using WebAppTodo.Web.Models;

public class PokemonService
{
    private static readonly string url = "https://pokeapi.co/api/v2/pokemon";

    public async Task<PokeList> GetPokeList()
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<PokeList>(url);
    }

    public async Task<Pokemon> GetPokemon(string pokeUrl)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Pokemon>(pokeUrl);
    }
}