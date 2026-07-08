using System.Text.Json.Serialization;

namespace PokeApi.Client.Dtos;

public class Ability
{
    [JsonPropertyName("ability")]
    public required Ability1 Ability1 { get; set; }
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
}

public class Ability1
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
