namespace ConsAppFiles;

internal static class FileManager
{
    internal static void ScriviTesto()
    {
        var path = Path.Combine(Path.GetTempPath(), "pippo.txt");
        var idx = 1;
        //File.AppendAllText("pippo.txt", s);

        while (true)
        {
            Console.Write("Inserisci il testo da salvare: ");
            var line = Console.ReadLine();

            if (line != null && line.Length > 0)
            {
                try
                {
                    File.AppendAllText(path, $"{idx} - {line}\n");
                    idx += 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore: {0}", ex.Message);
                }
            }
            else
            {
                break;
            }
        }
    }

    [Obsolete("Metodo non più utilizzato")]
    internal static void LeggiPromessiSposi(string filename)
    {
        var path = "/home/hp/Progetti/Ial/CSharp26/Esercizi/20260423-cs/EserciziConsole/ConsAppFiles";

        try
        {
            var fileTxt = File.ReadAllText(Path.Combine(path, filename))
                .Replace("\r", null)
                .Replace("\n", null)
                .Replace("  ", " ")
                .Replace("\\", null);
            
            var lowerText = fileTxt.ToLower();

            // Tutti i caratteri
            var letterCount = lowerText.Count();
            Console.WriteLine("Numero di lettere: {0}", letterCount);

            // Tutte le parole
            var wordList = lowerText.Replace('\'', ' ')
                                    .Replace('!', ' ')
                                    .Replace('?', ' ')
                                    .Replace(',', ' ')
                                    .Replace(';', ' ')
                                    .Replace(':', ' ')
                                    .Replace('.', ' ')
                                    .Split(" ");

            var wordCount = wordList.Count();
            Console.WriteLine("Numero di parole: {0}", wordCount);

            // Tutte le righe
            var linesCount = File.ReadAllLines(Path.Combine(path, filename)).Count();
            Console.WriteLine("Numero di righe: {0}", linesCount);

            // Tutte le occorrenze di "don abbondio"

            // tutte le parole più lunghe di 10 caratteri e stamparle a console
            var longWords = wordList.Where(m => m.Length > 10);
            Console.WriteLine("Parole più lunghe di 10 caratteri: ");
            foreach (var word in longWords)
            {
                Console.WriteLine(word);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Errore: {0}", ex.Message);
        }
    }
}
