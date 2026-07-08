namespace Pokemon.Web.Services;

using System.Web;
using Pokemon.Web.Models;

public class PokemonService
{
    private static readonly string url = "https://pokeapi.co/api/v2/pokemon";

    public async Task<PokeList> GetPokeList(int pageNum = 1, int limit = 20)
    {
        using var client = new HttpClient();

        var offset = pageNum * limit;
        var pokeList = await client.GetFromJsonAsync<PokeList>(GetPokeListUrl(offset, limit));

        if (pageNum - 1 > 0)
        {
            pokeList.PagePrev = pageNum - 1;
        }
        else
        {
            pokeList.PagePrev = null;
        }
        
        if (pageNum * limit < pokeList.Count)
        {
            pokeList.PageNext = pageNum + 1;
        }
        else
        {
            pokeList.PageNext = null;
        }

        foreach (var item in pokeList.Results)
        {
            item.id = GetPokemonIdFromUrl(item.url);
        }

        return pokeList;
    }

    public async Task<List<PokeListResult>> GetAllPokemons()
    {
        using var client = new HttpClient();
        var pokeList = await client.GetFromJsonAsync<PokeList>(GetPokeListUrl(0, 1351));

        foreach (var item in pokeList.Results)
        {
            item.id = GetPokemonIdFromUrl(item.url);
        }

        return pokeList.Results.ToList();
    }

    public async Task<Pokemon> GetPokemonById(int pokeId)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Pokemon>(url + '/' + pokeId + '/');
    }

    public async Task<Pokemon> GetPokemonByUrl(string pokeUrl)
    {
        using var client = new HttpClient();
        return await client.GetFromJsonAsync<Pokemon>(pokeUrl);
    }

    private int GetPokemonIdFromUrl(string url)
    {
        var slashPos = url.LastIndexOf('/');
        var pokeId = url.Substring(url.LastIndexOf('/', slashPos -1))
                        .Replace("/", null);
        var id = Convert.ToInt32(pokeId);

        return id;
    }

    private string GetPokeListUrl(int offset, int limit)
    {
        var uriBuilder = new UriBuilder(url);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["offset"] = offset.ToString();
        query["limit"] = limit.ToString();
        uriBuilder.Query = query.ToString();

        return uriBuilder.ToString();  
    }
}