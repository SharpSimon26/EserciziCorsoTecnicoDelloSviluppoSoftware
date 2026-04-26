using ConsAppFiles.ExtensionMethods;

string txtPromessiSposi;

try
{
    var path = Path.Combine(Environment.CurrentDirectory, "Data", "i_promessi_sposi.txt");
    txtPromessiSposi = await File.ReadAllTextAsync(path);
}
catch (Exception ex)
{
    Console.WriteLine("Si è verificato un errore: {0}", ex.Message);
    return;
}

if (string.IsNullOrWhiteSpace(txtPromessiSposi))
{
    Console.WriteLine("Il file da esaminare è vuoto");
    return;
}

// Calcola numero di caratteri, parole e righe
Console.WriteLine("Il file contiene {0} caratteri, {1} parole, {2} righe", 
        txtPromessiSposi.CountCharacters(),
        txtPromessiSposi.CountWords(),
        txtPromessiSposi.CountLines());

// Calcola il numero di volte in cui le parole specificate compaiono nel testp
var textToFind = "Don Abbondio";
var caseSensitive = false;
Console.WriteLine("Il file contiene la parola \"{0}\" {1} volte",
        textToFind, 
        txtPromessiSposi.FindAllOccurrencies(textToFind, caseSensitive).Count());

// Cerca nel testo le parole di lunghezza superiore al minimo specificato 
var minLength = 15;
var longWords = txtPromessiSposi.FindAllWordsByLength(minLength);    
Console.WriteLine("Elenco delle parole con lunghezza di almeno {0} caratteri ({1}): ", minLength, longWords.Count());
if (longWords.Any())
{
    foreach (var longWord in longWords)
    {
        Console.WriteLine(longWord);
    }
}
else
{
    Console.WriteLine("Vuoto...");
}
