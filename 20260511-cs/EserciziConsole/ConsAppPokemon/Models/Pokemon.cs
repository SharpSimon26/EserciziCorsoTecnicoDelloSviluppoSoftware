using System.Text.Json.Serialization;

namespace ConsAppPokemon.Models;

public class Pokemon
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Height { get; set; }

    public int Weight { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }
}