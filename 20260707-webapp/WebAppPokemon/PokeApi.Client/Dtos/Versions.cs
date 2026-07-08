namespace PokeApi.Client.Dtos;

public class Versions
{
    public GenerationI generationi { get; set; }
    public GenerationIi generationii { get; set; }
    public GenerationIii generationiii { get; set; }
    public GenerationIv generationiv { get; set; }
    public GenerationV generationv { get; set; }
    public GenerationVi generationvi { get; set; }
    public GenerationVii generationvii { get; set; }
    public GenerationViii generationviii { get; set; }
    public GenerationIx generationix { get; set; }
}

public class GenerationI
{
    public RedBlue RedBlue { get; set; }
    public Yellow Yellow { get; set; }
}

public class GenerationIi
{
    public Crystal Crystal { get; set; }
    public Gold Gold { get; set; }
    public Silver Silver { get; set; }
}

public class GenerationIii
{
    public Emerald Emerald { get; set; }
    public FireredLeafgreen Fireredleafgreen { get; set; }
    public RubySapphire Rubysapphire { get; set; }
}

public class GenerationIv
{
    public DiamondPearl diamondpearl { get; set; }
    public HeartgoldSoulsilver heartgoldsoulsilver { get; set; }
    public Platinum platinum { get; set; }
}

public class GenerationV
{
    public BlackWhite blackwhite { get; set; }
}

public class GenerationVi
{
    public OmegarubyAlphasapphire omegarubyalphasapphire { get; set; }
    public XY xy { get; set; }
}

public class GenerationVii
{
    public Icons Icons { get; set; }
    public UltraSunUltraMoon Ultrasunultramoon { get; set; }
}

public class GenerationViii
{
    public BrilliantDiamondShiningPearl Brilliantdiamondshiningpearl { get; set; }
    public Icons1 Icons { get; set; }
}

public class GenerationIx
{
    public ScarletViolet scarletviolet { get; set; }
}
