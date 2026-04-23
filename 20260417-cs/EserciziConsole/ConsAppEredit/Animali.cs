namespace ConsAppEredit;

internal interface IMammifero
{
    
}

internal abstract class Animale
{
    protected virtual void Mangia()
    {
        Console.WriteLine("Gnam gnam gnam");
    }
}

internal class Cane : Animale
{
    public static void Abbaia()
    {
        Console.WriteLine("Bau bau bau");
    }
}

internal class PastoreTedesco : Cane
{
    public static void FaiLaGuardia()
    {
        Console.WriteLine("RRRRRRRRRRRRRRRRRRRRRRrrrrr!!!");
    }
}

internal class Gatto : Animale
{
    public static void Miagola()
    {
        Console.WriteLine("Miiiaaao!!");
    }
}

internal class Canarino : Animale
{
    public static void Canta()
    {
        Console.WriteLine("CiuiuiuiCiciAhAhAhUiUiCicici!!");
    }
}

// Pesci

internal class Pesce : Animale
{
    public static void Nuota()
    {
        Console.WriteLine("swim swim");
    }

    public static void FaiBollicine()
    {
        Console.WriteLine("Oo.. Oo.. Oo.");
    }
}

internal class Carassio : Pesce
{
    
}

internal class Carpa : Pesce
{
    
}

internal class Trota : Pesce
{
    
}
