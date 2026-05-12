using System.Net.Http.Json;
using ConsAppPokemonSpectre.Models;

namespace ConsAppPokemonSpectre.Clients;

public class PokemonClient : IDisposable
{
    private const string POKELIST_API_ENDPOINT = "https://pokeapi.co/api/v2/pokemon";
    private const string POKEMON_API_ENDPOINT = "https://pokeapi.co/api/v2/pokemon/{id}";
    private readonly HttpClient httpClient;

    public PokemonClient()
    {
        httpClient = new()
        {
            Timeout = TimeSpan.FromMinutes(5)
        };
    }

    public async Task<PokeList?> GetPokemonListAsync(string? url = null)
    {
        return await httpClient.GetFromJsonAsync<PokeList>(string.IsNullOrEmpty(url) ? POKELIST_API_ENDPOINT : url);
    }

    public async Task<Pokemon?> GetPokemonByIdAsync(int id)
    {
        return await httpClient.GetFromJsonAsync<Pokemon>(POKEMON_API_ENDPOINT.Replace("{id}", id.ToString()));
    }

    public async Task<Pokemon?> GetPokemonByUrlAsync(string url)
    {
        return await httpClient.GetFromJsonAsync<Pokemon>(url);
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }
}