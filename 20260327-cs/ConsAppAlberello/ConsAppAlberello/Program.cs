Console.Write("Inserisci la dimensione dell'albero: ");
if (!int.TryParse(Console.ReadLine(), out int dimensione) && dimensione > 0)
{
    Console.WriteLine("Errore: è necessario un numero intero positivo");
    return;
}

string riga;

// V0
var step = 1;
for (int i = 1; i <= dimensione * 2; i += 2)
{
    Console.Write(new string('_', dimensione - step));
    step++;
    Console.WriteLine(new string('x', i));
}

Console.WriteLine();

// V1
for (int i = 1; i <= dimensione; i++)
{
    riga = new string('*', i * 2).PadLeft(dimensione + i);
    Console.WriteLine(riga);
}

Console.WriteLine();

// V2
for (int i = 1; i <= dimensione * 2; i += 2)
{
    riga = new string('*', i).PadLeft(dimensione + ((i + 1) / 2));
    Console.WriteLine(riga);
}

Console.ReadLine();
