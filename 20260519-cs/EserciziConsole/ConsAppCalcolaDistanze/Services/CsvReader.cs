using System.Globalization;
using ConsAppCalcolaDistanze.Models;

namespace ConsAppCalcolaDistanze.Services;

public static class CsvReader
{
    public static async Task<IEnumerable<Coord>> ParseGpsFile(string fileName)
    {
        var coordinateGps = new List<Coord>();
        var fileTxtLista = (await File.ReadAllLinesAsync(Path.Join(Directory.GetCurrentDirectory(), "Contents", fileName)))?.Skip(1).ToList();
        if (fileTxtLista != null && fileTxtLista.Any())
        {
            for (int i = 0; i < fileTxtLista.Count; i++)
            {
                try
                {
                    var coordinata = ParseLine(fileTxtLista[i]);
                    coordinateGps.Add(coordinata);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Attenzione, formato di riga errato {0} : {1}", fileTxtLista[i], ex.Message);
                }
            }
        }

        return coordinateGps;
    }

    private static Coord ParseLine(string line)
    {
        var splitLine = line.Split(',');
        var coordinataGps = new Coord()
        {
            Lat = double.Parse(splitLine[0], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture),
            Lng = double.Parse(splitLine[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture),
            //Elev = double.Parse(splitLine[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture)
        };

        return coordinataGps;
    }
}