namespace ConsAppClassi;

internal class Provincia(string nomeCitta, float temperatura, bool isUs = false)
{
    public string NomeCitta { get; set; } = nomeCitta;
    public float Temperatura { get; set; } = temperatura;
    public bool isUS = isUs;

    public int Confronta(Provincia p)
    {
        switch(p.Temperatura)
        {
            case float t when t > Temperatura:
                return 1;
            case float t when t < Temperatura:
                return 2;
            default:
                return 0;
        }
    }

    public float GetTemperatura()
    {
        return GetTemperatura(isUS);
    }

    public float GetTemperatura(bool isus)
    {
        return !isus ? Temperatura : Temperatura * 1.8f + 32;
    }

    public string Stampa()
    {
        return $"{NomeCitta} -> {GetTemperatura()} {(isUS ? "°F" : "°C")}";
    }
}
