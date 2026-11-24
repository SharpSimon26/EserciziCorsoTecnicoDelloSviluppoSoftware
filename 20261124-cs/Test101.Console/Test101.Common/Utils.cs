namespace Test101.Common;

public static class Utils
{
    public static int Fattoriale(int x)
    {
        if (x < 0)
        {
            throw new ArgumentException(
                "Non posso fare il fattoriale di un numero negativo"
            );
        }

        if (x == 0)
        {
            return 0;
        }

        if (x == 1)
        {
            return 1;
        }

        return x * Fattoriale(x - 1);
    }
}
