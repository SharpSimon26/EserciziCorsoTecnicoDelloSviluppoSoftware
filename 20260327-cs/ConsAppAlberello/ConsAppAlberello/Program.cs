var dimensione = 16;
string riga;

// V1
for (int i = 1; i <= dimensione; i++)
{
    riga = new string('*', i * 2).PadLeft(dimensione + i);
    Console.WriteLine(riga);
}

Console.WriteLine();

// V2
for (int i = 1; i <= dimensione * 2; i+=2)
{
    riga = new string('*', i).PadLeft(dimensione + ((i + 1) / 2));
    Console.WriteLine(riga);
}
