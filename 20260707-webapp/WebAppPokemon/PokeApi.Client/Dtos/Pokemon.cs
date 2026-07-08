using System.Text.Json.Serialization;

namespace PokeApi.Client.Dtos;

public class Pokemon
{
    public Ability[] Abilities { get; set; } = [];
    public int BaseExperience { get; set; }
    public Cries? Cries { get; set; }
    public Form[] Forms { get; set; } = [];
    public GameIndices[] GameIndices { get; set; } = [];
    public int Height { get; set; }
    public HeldItems[] HeldItems { get; set; } = [];
    public int Id { get; set; }
    public bool IsDefault { get; set; }
    public required string LocationAreaEncounters { get; set; }
    public Move[] Moves { get; set; } = [];
    public required string Name { get; set; }
    public int Order { get; set; }
    public PastAbilities[] PastAbilities { get; set; } = [];
    public PastStats[] PastStats { get; set; } = [];
    public object[] PastTypes { get; set; } = [];
    public required Species Species { get; set; }
    public required Sprites Sprites { get; set; }
    public Stat2[] Stats { get; set; } = [];
    public Type[] Types { get; set; } = [];
    public int Weight { get; set; }
}

public class FireredLeafgreen
{
    public string back_default { get; set; }
    public string back_shiny { get; set; }
    public string front_default { get; set; }
    public string front_shiny { get; set; }
}

public class RubySapphire
{
    public string back_default { get; set; }
    public string back_shiny { get; set; }
    public string front_default { get; set; }
    public string front_shiny { get; set; }
}

public class DiamondPearl
{
    public string back_default { get; set; }
    public object back_female { get; set; }
    public string back_shiny { get; set; }
    public object back_shiny_female { get; set; }
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class HeartgoldSoulsilver
{
    public string back_default { get; set; }
    public object back_female { get; set; }
    public string back_shiny { get; set; }
    public object back_shiny_female { get; set; }
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class Platinum
{
    public string back_default { get; set; }
    public object back_female { get; set; }
    public string back_shiny { get; set; }
    public object back_shiny_female { get; set; }
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class ScarletViolet
{
    public string front_default { get; set; }
    public object front_female { get; set; }
}

public class BlackWhite
{
    public Animated animated { get; set; }
    public string back_default { get; set; }
    public object back_female { get; set; }
    public string back_shiny { get; set; }
    public object back_shiny_female { get; set; }
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class Animated
{
    public string back_default { get; set; }
    public object back_female { get; set; }
    public string back_shiny { get; set; }
    public object back_shiny_female { get; set; }
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class OmegarubyAlphasapphire
{
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class XY
{
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class Icons
{
    public string front_default { get; set; }
    public object front_female { get; set; }
}

public class UltraSunUltraMoon
{
    public string front_default { get; set; }
    public object front_female { get; set; }
    public string front_shiny { get; set; }
    public object front_shiny_female { get; set; }
}

public class BrilliantDiamondShiningPearl
{
    public string front_default { get; set; }
    public object front_female { get; set; }
}

public class Icons1
{
    public string front_default { get; set; }
    public object front_female { get; set; }
}

public class Move
{
    [JsonPropertyName("move")]
    public required Move1 Move1 { get; set; }
    public VersionGroupDetails[] VersionGroupDetails { get; set; } = [];
}

public class Move1
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class VersionGroupDetails
{
    public int LevelLearnedAt { get; set; }
    public required MoveLearnMethod MoveLearnMethod { get; set; }
    public int? Order { get; set; }
    public required VersionGroup VersionGroup { get; set; }
}

public class MoveLearnMethod
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class VersionGroup
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class PastAbilities
{
    public Ability2[] Abilities { get; set; } = [];
    public required Generation Generation { get; set; }
}

public class Generation
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Ability2
{
    public required object Ability { get; set; }
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
}

public class PastStats
{
    public required Generation1 Generation { get; set; }
    public Stat[] Stats { get; set; } = [];
}

public class Generation1
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Stat
{
    public int BaseStat { get; set; }
    public int Effort { get; set; }
    [JsonPropertyName("stat")]
    public required Stat1 Stat1 { get; set; }
}

public class Stat1
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Stat2
{
    public int BaseStat { get; set; }
    public int Effort { get; set; }
    [JsonPropertyName("stat")]
    public required Stat3 Stat3 { get; set; }
}

public class Stat3
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}

public class Type
{
    public int Slot { get; set; }
    [JsonPropertyName("type")]
    public required Type1 Type1 { get; set; }
}

public class Type1
{
    public required string Name { get; set; }
    public required string Url { get; set; }
}