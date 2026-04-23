namespace ConsAppEccezioni;

internal class Printer : IDisposable
{
    public Printer()
    {
        // collegati alla stampante
    }

    public static Printer Connect()
    {
        // parte asincrona
        return new Printer();
    }

    public void Dispose()
    {
        // Chiudi la connessione alla stampante
        int a = 1;
    }
}