using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeApi.Client.Services;
using PokeApi.Client.Dtos;

namespace PokeApi.Web.Pages;

public class PokemonDetailModel : PageModel
{
    private readonly PokeApiClient _pokeApiClient;
    public required Pokemon Pokemon { get; set; }

    public PokemonDetailModel(PokeApiClient pokeApiClient)
    {
        _pokeApiClient = pokeApiClient;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var pokemon = await _pokeApiClient.GetPokemonById(id);

        if (pokemon != null)
        {
            Pokemon = pokemon;

            return Page();        
        }
        else
        {
            return RedirectToPage("Error");
        }
    }
}

