float[] temperature = [14, 12, 11, 9];
string[] citta = ["Trieste", "Udine", "Pordenone", "Gorizia"];

int minTempIdx = 0;
int maxTempIdx = 0;

for (int i = 0; i < temperature.Length; i++)
{
    if (temperature[i] < temperature[minTempIdx])
    {
        minTempIdx = i;
    }

    if (temperature[i] > temperature[maxTempIdx])
    {
        maxTempIdx = i;
    }
}

Console.WriteLine($"La città più calda è {citta[maxTempIdx]} con {temperature[maxTempIdx]}°");
Console.WriteLine($"La città più fredda è {citta[minTempIdx]} con {temperature[minTempIdx]}°");
