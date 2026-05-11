namespace ConsAppSpectreSelection3;

public interface IOperazione
{
    string GetOperazione();
    float Processa(float a, float b);
}

public class Somma : IOperazione
{
    public string GetOperazione()
    {
        return "Somma";
    }

    public float Processa(float a, float b)
    {
        return a + b;
    }
}

public class Sottrazione : IOperazione
{
    public string GetOperazione()
    {
        return "Sottrazione";
    }

    public float Processa(float a, float b)
    {
        return a - b;
    }
}

public class Moltiplicazione : IOperazione
{
    public string GetOperazione()
    {
        return "Moltiplicazione";
    }

    public float Processa(float a, float b)
    {
        return a * b;
    }
}

public class Divisione : IOperazione
{
    public string GetOperazione()
    {
        return "Divisione";
    }

    public float Processa(float a, float b)
    {
        return a / b;
    }
}