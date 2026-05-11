using System.Text.Json.Serialization;

namespace ConsAppPokemonSpectre.Models;

public class Pokemon
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Height { get; set; }

    public int Weight { get; set; }

    public int Order { get; set; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; set; }

    [JsonPropertyName("location_area_encounters")]
    public string? LocationAreaEncounters { get; set; }
}