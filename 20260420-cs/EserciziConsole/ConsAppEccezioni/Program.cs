using ConsAppEccezioni;
using ConsAppEccezioni.Exceptions;

static int PrendiValore(string msg)
{
    while(true)
    {
        try
        {
            Console.Write(msg);
            return int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Valore non valido, riprova...");
        }
        finally
        {
            // Codice eseguito in ogni condizione sia che completi il try che causi un'eccezione ed entri in un catch
        }
    }
}

int v1 = PrendiValore("Inserisci il primo addendo: ");
int v2 = PrendiValore("Inserisci il secondo addendo: ");

Console.WriteLine("La Somma di {0} e {1} è uguale a {2}", v1, v2, v1+v2);


using (Printer p1 = Printer.Connect())
{
    // faccio le mie cose
    int b = 3;
}