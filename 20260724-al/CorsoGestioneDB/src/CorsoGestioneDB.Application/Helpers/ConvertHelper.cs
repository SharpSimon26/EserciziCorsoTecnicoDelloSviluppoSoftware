using CorsoGestioneDB.Application.Models;
using System.Globalization;

namespace CorsoGestioneDB.Application.Helpers;

public static class ConvertHelper
{
    public static ConvertResult<int> ToInt(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new ConvertResult<int>(value, null, "La conversione in int è fallita, il valore è Null");
        }

        if (int.TryParse(value, CultureInfo.InvariantCulture, out int intValue))
        {
            return new ConvertResult<int>(value, intValue);
        }
        else
        {
            return new ConvertResult<int>(value, null, $"La conversione di {value} in int è fallita");
        }
    }

    public static ConvertResult<decimal> ToDecimal(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new ConvertResult<decimal>(value, null, "La conversione in decimal è fallita, il valore è Null");
        }

        var cleanedValue = value.Trim();

        var cultureIt = CultureInfo.GetCultureInfo("it-IT"); // cultura italiana -> supporta il . per le migliaia
        var cultureInv = CultureInfo.InvariantCulture; // cultura internazionale , per i decimali
        CultureInfo cultureToUse;

        int lastDot = cleanedValue.LastIndexOf('.');
        int lastComma = cleanedValue.LastIndexOf(',');

        if (lastComma > lastDot)
        {
            cultureToUse = cultureIt;
        }
        else
        {
            cultureToUse = cultureInv;
        }

        if (decimal.TryParse(value, NumberStyles.Any, cultureToUse, out decimal decValue))
        {
            return new ConvertResult<decimal>(value, decValue);
        }
        else
        {
            return new ConvertResult<decimal>(value, null, $"La conversione di {value} in decimal è fallita");
        }
    }

    public static ConvertResult<DateTime> ToDateTime(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new ConvertResult<DateTime>(value, null, "La conversione in DateTime è fallita, il valore è Null");
        }

        if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dtValue))
        {
            return new ConvertResult<DateTime>(value, dtValue);
        }
        else
        {
            return new ConvertResult<DateTime>(value, null, $"La conversione di {value} in DateTime è fallita");
        }
    }
}
