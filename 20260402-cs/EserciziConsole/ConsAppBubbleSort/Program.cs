int[] valori = { 42, 26, 10, 89, 32, 67, 88, 12, 4, 65, 13, 23 };
int n = valori.Length;
bool scambiato;

for (int i = 0; i < n - 1; i++)
{
    scambiato = false;
    // Il ciclo interno si accorcia a ogni passaggio: j < n - 1 - i
    for (int j = 0; j < n - 1 - i; j++)
    {
        if (valori[j] > valori[j + 1])
        {
            // Scambio (Swap)
            int temp = valori[j];
            valori[j] = valori[j + 1];
            valori[j + 1] = temp;
            
            scambiato = true;
        }
    }

    // Se non ci sono stati scambi, l'array è già ordinato!
    if (!scambiato) break;
}
