using CorsoGestioneDB.Application.Helpers;

namespace CorsoGestioneDB.Application.Tests;

public class ConverHelperTests
{
    [Theory]
    [InlineData("13", 13)]
    [InlineData("   47  ", 47)]
    public void Convert_String_Returns_Integer(string? value, int? atteso)
    {
        var risultato = ConvertHelper.ToInt(value);
        Assert.True(risultato.Success);
        Assert.Equal(value, risultato.OriginalValue);
        Assert.Equal(atteso, risultato.Value);
    }

    [Theory]
    [InlineData("10.3", 10.3, true)]
    [InlineData(" 113.71 ", 113.71, true)]
    [InlineData("1.234,50", 1234.50, true)]
    [InlineData("13,71", 13.71, true)]
    [InlineData(null, null, false)]
    [InlineData("dieci", null, false)]    
    public void Convert_String_Returns_Decimal(string? value, double? atteso, bool success)
    {
        decimal? valoreAtteso = (decimal?)atteso;
        var risultato = ConvertHelper.ToDecimal(value);
        Assert.Equal(risultato.Success, success);
        Assert.Equal(valoreAtteso, risultato.Value);
    }
}
