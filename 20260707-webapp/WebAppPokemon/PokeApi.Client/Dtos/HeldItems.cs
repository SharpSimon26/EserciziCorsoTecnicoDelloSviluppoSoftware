namespace PokeApi.Client.Dtos;

public class HeldItems
{
    public required Item Item { get; set; }
    public VersionDetails[] VersionDetails { get; set; } = [];
}

public class Item
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class VersionDetails
{
    public int Rarity { get; set; }
    public Version1 Version { get; set; }
}

public class Version1
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}
