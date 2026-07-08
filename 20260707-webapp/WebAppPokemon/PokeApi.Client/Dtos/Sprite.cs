namespace PokeApi.Client.Dtos;

public class Sprites
{
    public required string BackDefault { get; set; }
    public required object BackFemale { get; set; }
    public required string BackShiny { get; set; }
    public required object BackShinyFemale { get; set; }
    public required string FrontDefault { get; set; }
    public required object FrontFemale { get; set; }
    public required string FrontShiny { get; set; }
    public required object FrontShinyFemale { get; set; }
    public required Other Other { get; set; }
    public required Versions Versions { get; set; }
}
