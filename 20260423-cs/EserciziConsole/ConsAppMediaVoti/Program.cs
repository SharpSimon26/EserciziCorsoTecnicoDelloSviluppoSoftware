using ConsAppMediaVoti;

//float[] voti = new float[0];
var voti = new ElasticArray<float>();

while (true)
{
    Console.Write("Inserisci un voto: ");
    string? s = Console.ReadLine();
    if (s  == "")
    {
        break;
    }

    float voto = 0;

    if (float.TryParse(s, out voto))
    {
        //Array.Resize(ref voti, voti.Length + 1);
        //voti[voti.Length - 1] = voto;

        voti.Push(voto);
    }
}

float somma = 0;

for (int i = 0; i < voti.GetLength(); i++)
{
    somma += voti.GetItem(i);  //voti[i];
}

float media = somma / voti.GetLength();

Console.WriteLine("La media dei voti è {0}", media);
