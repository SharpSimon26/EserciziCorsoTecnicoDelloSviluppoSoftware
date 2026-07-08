using System.Text.Json.Serialization;

namespace Pokemon.Web.Models;

public class PokeList
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("results")]
    public IEnumerable<PokeListResult> Results { get; set; } = [];

    public int? PagePrev { get; set; }
    public int? PageNext { get; set; }
}
