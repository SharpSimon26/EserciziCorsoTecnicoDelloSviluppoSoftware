using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Web.Services;

namespace Pokemon.Web.Pages;

public class PokemonDetailModel : PageModel
{
    public required PokemonService pokemonService;
    public Models.Pokemon pokemon { get; set; }

    public PokemonDetailModel()
    {
        pokemonService = new PokemonService();
    }

    public async Task OnGet(int id)
    {
        pokemonService = new PokemonService();
        pokemon = await pokemonService.GetPokemonById(id);
    }
}

