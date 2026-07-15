namespace IalCypher.Lib;

public static class Crypt
{
    public static string Rot(int shift, string message)
    {
        var arrMessage = message.ToLower().ToCharArray();
        var arrMsgEnc = arrMessage.Select(c => 
        {
            var charNum = ((c - 'a' + shift + 26) % 26) + 'a';
            var encryptedChar = Convert.ToChar(charNum);
            return encryptedChar;
        })
        .ToList();

        return string.Join(null, arrMsgEnc);
    }

    // Rot con le sole lettere dell'alfabeto italiano
    public static string RotIta(int shift, string message)
    {
        var alfabeto = "abcdefghilmnopqrstuvz";
        var arrMessage = message.ToLower().ToCharArray();
        var arrMsgEnc = arrMessage.Select(c => 
        {
            var charIndex = alfabeto.IndexOf(c);
            if (charIndex < 0)
            {
                return c;
            }
            var encCharIndex = (alfabeto.IndexOf(c) + shift + 21) % 21;
            var encryptedChar = alfabeto[encCharIndex];
            return encryptedChar;
        })
        .ToList();

        return string.Join(null, arrMsgEnc);
    }

    public static string UnRot(int shift, string encryptedMessage)
    {
        var arrEncryptedMessage = encryptedMessage.ToLower().ToCharArray();
        var arrMessageDec = arrEncryptedMessage.Select(c => 
        {
            var charNum = ((c - 'a' - shift + 26) % 26) + 'a';
            return Convert.ToChar(charNum);
        })
        .ToList();

        return string.Join(null, arrMessageDec);
    }

    // UnRot con le sole lettere dell'alfabeto italiano
    public static string UnRotIta(int shift, string encryptedMessage)
    {
        var alfabeto = "abcdefghilmnopqrstuvz";
        var arrEncryptedMessage = encryptedMessage.ToLower().ToCharArray();
        var arrMessageDec = arrEncryptedMessage.Select(c => 
        {
            var charIndex = alfabeto.IndexOf(c);
            if (charIndex < 0)
            {
                return c;
            }
            var decCharIndex = (alfabeto.IndexOf(c) - shift + 21) % 21;
            var decryptedChar = alfabeto[decCharIndex];
            return decryptedChar;
        })
        .ToList();

        return string.Join(null, arrMessageDec);
    }

    // 9 * N (posizione) + 11 (spostamento)
    public static string RotGen(int shuffle, int shift, string message)
    {
        var arrMessage = message.ToLower().ToCharArray();
        var arrMessageEncrypted = arrMessage.Select(c => 
        {
            var charNum = ((((c - 'a') * shuffle) + shift) % 26) + 'a';

            return Convert.ToChar(charNum);
        })
        .ToList();

        return string.Join(null, arrMessageEncrypted);
    }

    public static string UnRotGen(int shuffle, int shift, string encryptedMessage)
    {
        var inverse = ModInverse(shuffle, 26);
        var arrEncryptedMessage = encryptedMessage.ToLower().ToCharArray();
        var arrMessageDecrypted = arrEncryptedMessage.Select(c =>
        {
            var charNum = (c - 'a' - shift * inverse) % 26;
            var decryptedChar = Convert.ToChar(charNum + 'a');
            return decryptedChar;
        })
        .ToList();

        return string.Join(null, arrMessageDecrypted);
    }

    private static int ModInverse(int a, int modulo)
    {
        a %= modulo;

        for (int x = 1; x < modulo; x++)
        {
            if ((a * x) % modulo == 1)
            {
                return x;
            }
        }

        throw new ArgumentException("Il valore di shuffle non è invertibile.");
    }
}
