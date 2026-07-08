using System.Net.Http.Json;
using System.Text.Json;
using PokeApi.Client.Dtos;
using PokeApi.Client.Models;

namespace PokeApi.Client.Services;

public class PokeApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public PokeApiClient(HttpClient httpClient, JsonSerializerOptions jsonOptions)
    {
        _httpClient = httpClient;
        _jsonOptions = jsonOptions;
    }

    public async Task<PokeList?> GetPokeList()
    {
        var pokeListDto = await _httpClient.GetFromJsonAsync<PokeListDto>("pokemon", _jsonOptions);
        if (pokeListDto != null)
        {
            var pokeIds = pokeListDto.Results.Select(m =>
            {
                var id = GetPokemonIdFromUrl(m.Url);
                return id;
            });

            var pokemons = await GetPokemonsById(pokeIds);

            var pokeList = new PokeList
            {
                Count = pokeListDto.Count,
                Next = pokeListDto.Next,
                Previous = pokeListDto.Previous,
                Results = pokeListDto.Results.Select(m => {
                    var pokemonId = GetPokemonIdFromUrl(m.Url);
                    return new PokeListResult
                    {
                        Id = pokemonId,
                        Name = m.Name,
                        FrontDefault = pokemons.FirstOrDefault(p => p.Id == pokemonId)?.Sprites.FrontDefault ?? string.Empty
                    };
                }).ToArray()
            };

            return pokeList;
        }

        return null;
    }

    private static int GetPokemonIdFromUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            return 0;
        }
        
        var uri = new Uri(url);
        var lastSegment = uri.Segments[uri.Segments.Count()-1].TrimEnd('/');
        
        return int.TryParse(lastSegment, out var id) ? id : 0;
    }

    public async Task<Pokemon?> GetPokemonById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Pokemon>("pokemon/" + id.ToString(), _jsonOptions);
    }

    public async Task<IEnumerable<Pokemon>> GetPokemonsById(IEnumerable<int> ids)
    {
        var pokemons = await Task.WhenAll(ids.Select(async id =>
        {
            return await GetPokemonById(id);
        }));

        return pokemons.Where(m => m is not null)
                       .Select(m => m!);
    }
}
