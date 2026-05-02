namespace ConsAppDelegati.Utilities;

public delegate float Operazione(float a, float b);
public delegate string Read();
public delegate void Print(string s);

public class Calcolatrice
{
    private readonly Print _print;
    private readonly Read _read;

    public Calcolatrice(Print print, Read read) // (Action<string> print, Func<string> read)
    {
        _print = print;
        _read = read;
    }

    public void EseguiCalcolo(Operazione op)
    {
        float val1 = PrendiValore("Inserisci il primo valore");
        float val2 = PrendiValore("Inserisci il secondo valore");

        float ris = op(val1, val2);

        _print($"Il risultato è: {ris}");
    }

    private float PrendiValore(string msg)
    {
        while (true)
        {
            try
            {
                _print($"{msg}: ");
                string s = _read();
                float val = float.Parse(s);
                return val;
            }
            catch (Exception ex)
            {
                _print($"Valore non valido, riprova. {ex.Message}");
            }              
        }
    }
}