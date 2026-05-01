using ConsAppFunc.Utilities;

static void Stampa(string s)
{
    Console.WriteLine(s);
}

static string Leggi()
{
    return Console.ReadLine() ?? string.Empty;
}

var cal = new Calcolatrice(Stampa, Leggi);

// cal.EseguiCalcolo((a, b) => { return a + b; }); // Lambda function
cal.EseguiCalcolo((a, b) => a * b); //  
