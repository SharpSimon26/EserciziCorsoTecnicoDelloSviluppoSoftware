using ConsAppProfiloImmersione.Services;

try
{
    var divingLogEntries = await CsvReader.ParseFile("profilo.csv");
    var consumi = new List<float>();

    foreach (var entry in divingLogEntries)
    {
        var consumo = CalcolaConsumo(1, entry.ProfonditaMetri);
        consumi.Add(consumo);

        Console.WriteLine("Minuto: {0} - Profondità: {1} - Consumo: {2}", 
                            entry.TempoMinuti, entry.ProfonditaMetri, consumo);
    }

    var consumoTotale = consumi.Sum();

    Console.WriteLine("Consumo totale: {0} litri", consumoTotale);
}
catch (Exception ex)
{
    Console.WriteLine("Si è verificato un errore: {0}", ex.Message);
}


static float CalcolaConsumo(int tempoMinuti, float profonditaMetri)
{
    return 20 * tempoMinuti * ((profonditaMetri / 10) + 1);
}