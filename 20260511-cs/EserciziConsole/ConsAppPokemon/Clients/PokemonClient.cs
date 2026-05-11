using System.Net.Http.Json;
using ConsAppPokemon.Models;

namespace ConsAppPokemon.Clients;

public static class PokemonClient
{
    private const string POKELIST_API_ENDPOINT = "https://pokeapi.co/api/v2/pokemon";
    private const string POKEMON_API_ENDPOINT = "https://pokeapi.co/api/v2/pokemon/{id}";

    public static async Task<PokeList?> GetPokemonList()
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<PokeList>(POKELIST_API_ENDPOINT);
    }

    public static async Task<Pokemon?> GetPokemonByIdAsync(int id)
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<Pokemon>(POKEMON_API_ENDPOINT.Replace("{id}", id.ToString()));
    }

    public static async Task<Pokemon?> GetPokemonByUrlAsync(string url)
    {
        using HttpClient httpClient = new();
        httpClient.Timeout = TimeSpan.FromMinutes(5);
        return await httpClient.GetFromJsonAsync<Pokemon>(url);
    }
}