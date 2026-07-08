using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Web.Models;
using Pokemon.Web.Services;

namespace Pokemon.Web.Pages;

public class IndexModel : PageModel
{
    public PokeList pokeList { get; set; }
    private readonly PokemonService pokemonService;

    public IndexModel()
    {
        pokemonService = new PokemonService();
    }

    public async Task OnGet()
    {
        pokeList = await pokemonService.GetPokeList();
    }
}
