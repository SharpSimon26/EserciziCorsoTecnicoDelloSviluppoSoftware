using IalCypher.Lib;

Console.WriteLine(Crypt.Rot(5, "Buongiorno"));
Console.WriteLine(Crypt.UnRot(5, "gztslntwst"));

// Console.WriteLine(Crypt.RotGen(9, 11, "Buongiorno"));
// Console.WriteLine(Crypt.UnRotGen(9, 11, "ujhynfhiyh"));

var validShuffles = new int[] { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
var textToDecrypt = "DZZDFFDUHLONNUUNGAFNENONLDOONDOODRUDVHVZD";
                  //"ATTACCAREGLIIRRIDUCIBILIGALLIALLAORASESTA"

//var decryptedText = Crypt.UnRotGen(1, 3, textToDecrypt);
//Console.WriteLine(decryptedText);

Console.WriteLine(Crypt.UnRotIta(3, textToDecrypt));
Console.WriteLine(Crypt.RotIta(3, "attaccaregliirriducibiligalliallaorasesta"));

/*
// ciclo per shift
for (int shift = 0; shift < 26; shift++)
{
    // ciclo per shuffle
    for (int j = 0; j < validShuffles.Length; j++)
    {
        var decryptedText = Crypt.UnRotGen(validShuffles[j], shift, textToDecrypt);
        Console.WriteLine($"{decryptedText} - Shift: {shift,2} - Shuffle: {validShuffles[j],2}");
    }
}
*/
