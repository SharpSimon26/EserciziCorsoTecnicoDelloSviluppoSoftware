using System.Globalization;

int[] valori = [42, 26, 10, 89, 32, 67, 88, 12, 4, 65, 13, 23];
/*
for (int i = 0; i < valori.Length; i++)
{
    for (int j = 0; j < valori.Length; j++)
    {
        if (i != j && valori[i] < valori[j])
        {
            var tmpI = valori[i];
            var tmpJ = valori[j];
            valori[i] = tmpJ;
            valori[j] = tmpI;
        }
    }
}

Console.WriteLine("Ordinamento array di numeri interi:");
Console.WriteLine(string.Join(", ", valori));
*/
// ---------------------------------------------------------------------
/*
int[] ordinati = new int[valori.Length];

for (int i = 0; i < valori.Length; i++)
{
    int minimo = valori[i];
    for (int j = i; j < valori.Length; j++)
    {
        int v = valori[i];
        if (v < minimo)
        {
            ordinati[i] = v;
            minimo = v;
        }        
    }
}
*/

// Selection Sort O(n2)
/*
for (int i = 0; i < valori.Length; i++)
{
    int minIndex = i;
    for (int j = i; j < valori.Length; j++)
    {
        if (valori[j] < valori[minIndex])
        {
            minIndex = j;
        }
    }    
    int tmp = valori[i];
    valori[i] = valori[minIndex];
    valori[minIndex] = tmp;
}
*/

// Bubble Sort
bool swapped = true;
while (swapped)
{
    swapped = false;
    for (int i = 1; i < valori.Length; i++)
    {
        if (valori[i] < valori[i - 1])
        {
            int tmp = valori[i - 1];
            valori[i - 1] = valori[i];
            valori[i] = tmp;
            swapped = true;
        }
    }    
}

Console.WriteLine("Ordinamento array di numeri interi:");
Console.WriteLine(string.Join(", ", valori));
