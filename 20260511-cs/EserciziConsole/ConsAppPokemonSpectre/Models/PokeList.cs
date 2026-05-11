namespace ConsAppPokemonSpectre.Models;

public class PokeList
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public IEnumerable<Result> Results { get; set; } = [];
}
