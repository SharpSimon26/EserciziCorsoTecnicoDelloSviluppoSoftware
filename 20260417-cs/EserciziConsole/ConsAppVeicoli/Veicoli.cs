namespace ConsAppVeicoli;

internal interface IVeicolo
{
    float GetVelocitaMax();
    int GetPasseggeri();    
    int GetNumRuote();
}

internal interface ICaricabile
{
    float GetCapacitaCarico(); 
}

internal class Moto : IVeicolo
{
    private readonly int _numPasseggeri = 2;
    private readonly int _numRuote = 2;
    private readonly float _velocitaMax = 300;

    public int GetNumRuote()
    {
        return _numRuote;
    }

    public int GetPasseggeri()
    {
        return _numPasseggeri;
    }

    public float GetVelocitaMax()
    {
        return _velocitaMax;
    }
}

internal class Auto : IVeicolo, ICaricabile
{
    private readonly int _numPasseggeri = 5;
    private readonly int _numRuote = 4;
    private readonly float _velocitaMax = 220;
    private readonly float _capacita = 200;

    public int GetNumRuote()
    {
        return _numRuote;
    }

    public int GetPasseggeri()
    {
        return _numPasseggeri;
    }

    public float GetVelocitaMax()
    {
        return _velocitaMax;
    }

    public float GetCapacitaCarico()
    {
        return _capacita;
    }    
}

internal class Camion : IVeicolo, ICaricabile
{
    private readonly int _numPasseggeri = 3;
    private readonly int _numRuote = 6;
    private readonly float _velocitaMax = 180;
    private readonly float _capacita = 80000;

    public int GetNumRuote()
    {
        return _numRuote;
    }

    public int GetPasseggeri()
    {
        return _numPasseggeri;
    }

    public float GetVelocitaMax()
    {
        return _velocitaMax;
    }

    public float GetCapacitaCarico()
    {
        return _capacita;
    }
}