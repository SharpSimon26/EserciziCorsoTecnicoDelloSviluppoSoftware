using System.Text;

namespace IalCypher.Lib;

public class GridCypher
{
    private readonly Dictionary<char, char> _encryptMap;

    public GridCypher(string key, bool clockwise = true)
    {
        _encryptMap = SetKey(key, clockwise);
    }

    private static Dictionary<char, char> SetKey(string chiave, bool clockwise)
    {
        var normalizedKey = NormalizeKey(chiave);

        // indici caratteri con rotazione a destra e a sinistra
        const string clockwiseGrid = "abcde" +
                                     "prstf" +
                                     "oyzug" +
                                     "nxwvh" +
                                     "mlkjiq";

        const string counterClockwiseGrid = "edcba" +
                                            "ftsrp" +
                                            "guzyo" +
                                            "hvwxn" +
                                            "ijklmq";

        // Lista per caratteri cifrati inizializzata con spazi
        var cypherAlphabet = new string(' ', 26).ToList();

        // Inserire le singole lettere della chiave nel dizionario
        var currentIndex = 1;
        var step = 2;

        // ciclo per i caratteri della chiave normalizzata
        foreach (var letter in normalizedKey)
        {
            var index = currentIndex % 26;

            // evita di sovrascrivere caratteri esistenti
            if (cypherAlphabet[index] != ' ')
            {
                while (cypherAlphabet[index] != ' ')
                {
                    index = (index + 1) % 26;
                }
            }

            cypherAlphabet[index] = letter;
            currentIndex += step; 
        }

        var grid = clockwise ? clockwiseGrid : counterClockwiseGrid;
        var map = new Dictionary<char,char>();

        // crea il dizionario
        for (int i = 0; i < grid.Length; i++)
        {
            map.Add(grid[i], cypherAlphabet[i]);
        }

        return map;
    }

    private static string NormalizeKey(string key)
    {
        // rimuove tutti i caratteri che non siano lettere e i caratteri doppi
        var letters = key.ToLower()
                         .Where(char.IsLetter) //meglio di -> .Replace(" " , null)
                         .Distinct()
                         .ToList();

        // ciclo per verificare la presenza di tutte le lettere nella chiave
        foreach (var ch in "abcdefghijklmnopqrstuvwxyz")
        {
            if (!letters.Contains(ch))
            {
                letters.Add(ch);
            }
        }

        return new string(letters.ToArray());
    }

    // Legge il messaggio in chiaro e sostituire le lettere cifrate a quelle in chiaro in base al dizionario
    public string Encrypt(string plainText)
    {
        var encryptedText = plainText.ToLower()
                             .Where(char.IsLetter)
                             .Select(c => _encryptMap.GetValueOrDefault(c))
                             .ToArray();

        return new string(encryptedText);
    }

    // Leggere il messaggio cifrato e sostituire le lettere in chiaro a quelle cifrate in base al dizionario chiave
    public string Decrypt(string encryptedText)
    {
        var decryptedText = encryptedText.ToLower()
                                         .Where(char.IsLetter)
                                         .Select(c => _encryptMap.FirstOrDefault(m => m.Value == c).Key)
                                         .ToArray();

        return new string(decryptedText);
    }
}
