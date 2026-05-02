using ConsAppDelegati.Utilities;

var cal = new Calcolatrice(Stampa, Leggi);
cal.EseguiCalcolo(Somma);
cal.EseguiCalcolo(Moltiplicazione);
// cal.EseguiCalcolo((a, b) => { return a + b; }); // Scrittura alternativa con Lambda function
// cal.EseguiCalcolo((a, b) => a * b);


float Somma(float x, float y)
{
    return x + y;
}

float Moltiplicazione(float x, float y)
{
    return x * y;
}

string Leggi()
{
    return Console.ReadLine() ?? string.Empty;
}

void Stampa(string s)
{
    Console.WriteLine(s);
}

/*
Action<string> Stampa2 = (s) =>
{
    Console.WriteLine(s);
};

Func<string> Leggi2 = () =>
{
    return Console.ReadLine() ?? string.Empty;
};
*/
