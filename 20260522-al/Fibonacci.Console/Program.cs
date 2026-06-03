// Calcolo ricorsivo del N esimo numero di Fibonacci
static long FibonacciRicorsivo(long n)
{
    if (n == 1 || n == 2)
    {
        return 1;
    }

    return FibonacciRicorsivo(n - 1) + FibonacciRicorsivo(n - 2);
}

// Calcolo ricorsivo del N esimo numero di Fibonacci con stampa delle operazioni effettuate
static long FibonacciRicorsivo2(int n, int livello = 0)
{
    // visualizza la profondità della ricorsione tramite gli spazi
    var spazi = new string(' ', livello * 4);

    Console.WriteLine($"{spazi}Fib({n}) chiamata");

    // n == 0 || n == 1  <-- Inserendo questi valori la serie parte da 0 anzichè 1
    if (n == 1 || n == 2)
    {
        Console.WriteLine($"{spazi}Fib({n}) = 1");
        return 1;
    }

    long a = FibonacciRicorsivo2(n - 1, livello + 1);
    long b = FibonacciRicorsivo2(n - 2, livello + 1);

    long risultato = a + b;

    Console.WriteLine($"{spazi}Fib({n}) = Fib({n - 1}) + Fib({n - 2}) = {a} + {b} = {risultato}");

    return risultato;
}

// Calcolo iterativo del N esimo numero di Fibonacci
static long FibonacciIterativo(int n)
{
    if (n < 1)
    {
        return 0;
    }

    long a = 0;
    long b = 1;
    long temp;

    for (int i = 2; i <= n; i++)
    {
        temp = a + b;
        a = b;
        b = temp;

        Console.WriteLine($"Idx: {i} a: {a} b: {b} temp: {temp}");
    }

    return b;
}

static IEnumerable<long> FibonacciSerie(int n)
{
    if (n < 1) throw new ArgumentException("Specificare un valore positivo maggiore di 0");

    long a = 0;
    long b = 1;
    long temp;

    for (int i = 1; i <= n; i++)
    {
        temp = a + b;
        a = b;
        b = temp;

        yield return a;
    }
}

foreach (var num in FibonacciSerie(50))
{
    Console.Write($"{num:n0}  ");
}

Console.WriteLine();
