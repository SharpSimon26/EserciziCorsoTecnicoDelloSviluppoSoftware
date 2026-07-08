using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTodo.Web.Services;
using WebAppTodo.Web.Models;

namespace WebAppTodo.Web.Pages;

public class PokemonModel : PageModel
{
    public PokeList pokeList { get; set; }

    public async Task OnGet()
    {
        var pokemonService = new PokemonService();
        pokeList = await pokemonService.GetPokeList();
    }
}
