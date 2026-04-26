namespace ConsAppFiles.ExtensionMethods;

public static class StringExtensions
{
    private static readonly string[] _splitChars = ["\r\n", "\r", "\n", " ", "'", "!", "?", ".", ",", ";", ":", "(", ")"];

    /// <summary>
    /// Conta i caratteri presenti nel testo specificato
    /// </summary>
    /// <param name="stringToProcess">Testo da esaminare</param>
    /// <returns>Numero di caratteri che compongono il testo</returns>
    public static int CountCharacters(this string stringToProcess)
    {
        var oneLineString = stringToProcess.ReplaceLineEndings(" ");
        return oneLineString.Count();
    }

    /// <summary>
    /// Conta le parole presenti nel testo specificato
    /// </summary>
    /// <param name="stringToProcess">Testo da esaminare</param>
    /// <returns>Numero di parole che compongono il testo</returns>
    public static int CountWords(this string stringToProcess)
    {
        var wordList = stringToProcess.Split(_splitChars, 
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        return wordList.Count();
    }

    /// <summary>
    /// Conta le righe presenti nel testo specificato
    /// </summary>
    /// <param name="stringToProcess">Testo da esaminare</param>
    /// <returns>Numero di righe che compongono il testo</returns>
    public static int CountLines(this string stringToProcess)
    {
        var rows = stringToProcess.Split(["\r\n", "\r", "\n"], StringSplitOptions.None);
        return rows.Count();
    }

    /// <summary>
    /// Cerca la sottostringa nel testo specificato
    /// </summary>
    /// <param name="stringToProcess">Testo da esaminare</param>
    /// <param name="textToFind">Testo da cercare</param>
    /// <param name="isCaseSensitive">Rispetta la differenza maiuscole / minuscole</param>
    /// <returns>Array di indici ai quali si trova la stringa cercata nel testo</returns>
    public static IEnumerable<int> FindAllOccurrencies(this string stringToProcess, string textToFind, bool isCaseSensitive = false)
    {
        var matchIndices = new List<int>();
        int startpos = 0;
        var oneLineString = stringToProcess.ReplaceLineEndings(" ");

        while (startpos != -1)
        {
            startpos = oneLineString.IndexOf(textToFind, startpos, isCaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
            if (startpos != -1)
            {
                matchIndices.Add(startpos);
                startpos += textToFind.Length;
            }
        }

        return matchIndices;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stringToProcess">Testo da esaminare</param>
    /// <param name="minLength">Lunghezza minima della parola</param>
    /// <returns>Elenco di parole con lunghezza pari o superiore a quanto specificato</returns>
    public static IEnumerable<string> FindAllWordsByLength(this string stringToProcess, int minLength)
    {
        var wordList = stringToProcess.ToLower()
                                      .Split(_splitChars, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var orderedList = wordList.Where(m => m.Length >= minLength)
                                  .Distinct()
                                  .Order()
                                  .ToList();
        return orderedList;
    }
}