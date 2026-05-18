using System.Globalization;
using ConsAppProfiloImmersione.Models;

namespace ConsAppProfiloImmersione.Services;

public static class CsvReader
{
    public static async Task<IEnumerable<DivingLogEntry>> ParseFile(string fileName)
    {
        var divingLogEntries = new List<DivingLogEntry>();

        var divingLogTxt = (await File.ReadAllLinesAsync(Path.Join(Directory.GetCurrentDirectory(), "Contents", fileName)))?.Skip(1);
        if (divingLogTxt != null && divingLogTxt.Any())
        {
            foreach (var line in divingLogTxt)
            {
                divingLogEntries.Add(ParseLine(line));
            }            
        }

        return divingLogEntries;
    }

    private static DivingLogEntry ParseLine(string line)
    {
        var aLine = line.Split(',');
        var entry = new DivingLogEntry()
        {
            TempoMinuti = int.Parse(aLine[0]), 
            ProfonditaMetri = float.Parse(aLine[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture)
        };

        return entry;
    }
}