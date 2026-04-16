var arrVoti = new List<int>();
Console.WriteLine("Calcolo media voti");

while (true)
{
    Console.Write("Inserisci un voto o invio per terminare: ");
    var strVoto = Console.ReadLine();

    if (strVoto == string.Empty)
    {
        break;
    }

    if (int.TryParse(strVoto, out int voto))
    {
        if (voto > 0)
        {
            arrVoti.Add(voto);
        }
        else
        {
            Console.WriteLine("Inserisci un numero intero maggiore di 0"); 
        }
    }
    else
    {
        Console.WriteLine("Voto non riconosciuto");
    }
}

if (arrVoti.Count > 0)
{
    //Console.WriteLine($"La media di {arrVoti.Count} voti inseriti è: {Enumerable.Average(arrVoti)}");
    var sommaVoti = 0;
    foreach (var item in arrVoti)
    {
        sommaVoti += item;
    }
    Console.WriteLine($"La media di {arrVoti.Count} voti inseriti è: {sommaVoti / arrVoti.Count}");
}
else
{
    Console.WriteLine("Non sono stati inseriti voti su cui calcolare la media");
}
