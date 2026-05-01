namespace ConsAppDelegati;

public delegate float Operazione(float a, float b);
public delegate string Read();
public delegate void Print(string s);



public class Calcolatrice
{
    Action<string> _pippo;
    Func<string> _pluto; // func ammette 16 valori in ingresso e 1 in uscita   primo valore di func è il parametro e ultimo è il valore di ritorno
    Print _print;
    Read _read;

    public Calcolatrice(Print print, Read read) // (Action<string> print, Func<string> read)
    {
        _print = print;
        _read = read;
    }

    public void EseguiCalcolo(Operazione op)
    {
        float val1 = PrendiValore("Inserisci il primo valore: ");
        float val2 = PrendiValore("Inserisci il secondo valore: ");

        float ris = op(val1, val2);

        Console.WriteLine("Il risultato è {0}", ris);
    }

    private static float PrendiValore(string msg)
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Inserisci il primo valore: ");
                string s = Console.ReadLine();
                float val = float.Parse(s);
                return val;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Valore non valido, riprova. {0}", ex.Message);
            }              
        }
    }
}