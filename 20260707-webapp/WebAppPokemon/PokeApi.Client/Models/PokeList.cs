using PokeApi.Client.Dtos;

namespace PokeApi.Client.Models;

public class PokeList
{
    public int Count { get; set; } = 0;
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public PokeListResult[] Results { get; set; } = [];
}
