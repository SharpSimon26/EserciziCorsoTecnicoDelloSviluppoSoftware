namespace ConsAppFunc.Utilities;

public class Calcolatrice
{
    private Action<string> _print; // action accetta valori in ingresso ma non restituisce mai nulla
    private Func<string> _read; // func ammette 16 valori in ingresso e 1 in uscita   primo valore di func è il parametro e ultimo è il valore di ritorno

    public Calcolatrice(Action<string> print, Func<string> read)
    {
        _print = print;
        _read = read;
    }

    public void EseguiCalcolo(Func<float, float, float> operazione)
    {
        float val1 = PrendiValore("Inserisci il primo valore: ");
        float val2 = PrendiValore("Inserisci il secondo valore: ");

        float ris = operazione(val1, val2);

        Console.WriteLine("Il risultato è: {0}", ris);
    }

    private static float PrendiValore(string msg)
    {
        while (true)
        {
            try
            {
                Console.Write(msg);
                string s = Console.ReadLine() ?? string.Empty;
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