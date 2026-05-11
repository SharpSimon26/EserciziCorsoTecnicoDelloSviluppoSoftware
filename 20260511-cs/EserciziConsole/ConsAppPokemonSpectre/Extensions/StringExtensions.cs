namespace ConsAppPokemonSpectre.Extensions;

public static class StringExtensions
{
    public static string UcFirst(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        var chars = str.ToCharArray();
        chars[0] = char.ToUpper(chars[0]);

        return new string(chars);
    }
}