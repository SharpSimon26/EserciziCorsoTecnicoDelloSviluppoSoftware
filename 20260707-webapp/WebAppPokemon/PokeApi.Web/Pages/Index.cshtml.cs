using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeApi.Client.Models;
using PokeApi.Client.Services;

namespace PokeApi.Web.Pages;

public class IndexModel : PageModel
{
    private readonly PokeApiClient _pokeApiClient;    
    public required PokeList PokeList { get; set; }

    public IndexModel(PokeApiClient pokeApiClient)
    {
        _pokeApiClient = pokeApiClient;
    }

    public async Task OnGet()
    {
        PokeList = await _pokeApiClient.GetPokeList() ?? new();
    }
}
