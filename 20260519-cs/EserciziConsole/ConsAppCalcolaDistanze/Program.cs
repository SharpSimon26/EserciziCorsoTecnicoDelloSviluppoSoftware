using ConsAppCalcolaDistanze.Models;
using ConsAppCalcolaDistanze.Services;

var elencoDistanze = new List<double>();
var coordinateGps = new List<Coord>();

// Effettua il parsing del file csv e ottiene una lista di coordinate
try
{
    coordinateGps.AddRange(await CsvReader.ParseGpsFile("rilke.csv"));
}
catch(Exception ex)
{
    Console.WriteLine("Si è verificato un errore: {0}", ex.Message);
    return;
}

// Ciclo sulle coordinate per calcolare le distanze dei singoli segmenti del tracciato
for (int i = 0; i < coordinateGps.Count; i++)
{
    if (i > 0)
    {
        elencoDistanze.Add(coordinateGps[i].Distance(coordinateGps[i-1]));
    }
}

var sommaDistanze = elencoDistanze.Sum();
Console.WriteLine("Distanza totale del percorso: {0:F2} metri", sommaDistanze);

var distanzaPartenzaArrivo = coordinateGps[0].Distance(coordinateGps.Last());
Console.WriteLine("Distanza in linea d'aria dal punto di partenza al punto di arrivo: {0:F2} metri", distanzaPartenzaArrivo);