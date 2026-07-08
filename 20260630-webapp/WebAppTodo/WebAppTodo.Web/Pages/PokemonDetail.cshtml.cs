using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTodo.Web.Services;
using WebAppTodo.Web.Models;

namespace WebAppTodo.Web.Pages;

public class PokemonDetailModel : PageModel
{
    public Pokemon pokemon { get; set; }

    public async Task OnGet(string id)
    {
        var pokemonService = new PokemonService();
        pokemon = await pokemonService.GetPokemon(id);
    }
}

