namespace PokeApi.Client.Dtos;

public class Other
{
    public required DreamWorld DreamWorld { get; set; }
    public required Home Home { get; set; }
    public OfficialArtwork? Officialartwork { get; set; }
    public required Showdown Showdown { get; set; }
}
