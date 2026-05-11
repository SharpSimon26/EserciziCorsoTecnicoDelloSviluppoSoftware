using System.Net.Http.Json;
using ConsAppPokemonSpectre.Models;

namespace ConsAppPokemonSpectre.Clients;

public static class PokemonClient
{
    private const string POKELIST_API_ENDPOINT = "https://pokeapi.co/api/v2/pokemon";
    private const string POKEMON_API_ENDPOINT = "https://pokeapi.co/api/v2/pokemon/{id}";

    public static async Task<PokeList?> GetPokemonListAsync(string? url = null)
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<PokeList>(string.IsNullOrEmpty(url) ? POKELIST_API_ENDPOINT : url);
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