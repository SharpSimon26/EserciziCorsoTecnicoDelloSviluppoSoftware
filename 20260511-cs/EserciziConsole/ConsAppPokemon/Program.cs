using ConsAppPokemon.Clients;
using ConsAppPokemon.Models;

/*
for (int i = 1; i <= 20; i++)
{
    var pokemon = await PokemonClient.GetPokemonByIdAsync(i);
    if (pokemon != null)
    {
        Console.WriteLine("Id: {0} - Name: {1} - Height: {2} - Weight: {3} - Base Experience: {4}", 
            pokemon.Id, pokemon.Name, pokemon.Height, pokemon.Weight, pokemon.BaseExperience);
    }
}
*/
// var pokes = new List<Pokemon>();
var pokes = new List<Task<Pokemon>>();

var pokeList = await PokemonClient.GetPokemonList();
if (pokeList != null && pokeList.Results.Count() > 0)
{
    /*
    var tasks = new List<Task>();
    foreach(var item in pokeList.PokeItems)
    {
        tasks.Add(PokemonClient.GetPokemonByUrlAsync(item.Url));
    }

    // Task.WaitAll(tasks); <-- Metodo sincrono bloccante
    await Task.WhenAll();
    */

    //await Task.WhenAll(pokeList.Results.Select(r => GetDetail(r.Url)));

    foreach (var p in pokeList.Results)
    {
        pokes.Add(GetDetail(p.Url));
    }

    var pokemons = await Task.WhenAll(pokes);

    Console.WriteLine("Scaricati {0} Pokemon", pokemons.Count());
}

async Task<Pokemon> GetDetail(string pokemonUrl)
{
    while (true)
    {
        try
        {
            var pokemon = await PokemonClient.GetPokemonByUrlAsync(pokemonUrl);
            if (pokemon != null)
            {
                Console.WriteLine("Id: {0} - Name: {1} - Height: {2} - Weight: {3} - Base Experience: {4}", 
                    pokemon.Id, pokemon.Name, pokemon.Height, pokemon.Weight, pokemon.BaseExperience);

                // pokes.Add(pokemon);
                //break;
                return pokemon;
            }            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await Task.Delay(500);
        }
    }
}