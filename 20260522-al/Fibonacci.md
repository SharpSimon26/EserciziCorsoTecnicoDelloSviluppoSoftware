# Serie di Fibonacci

Calcolo del n esimo numero di Fibonacci usando il metodo ricorsivo
$$
\Large
fib(n) =
\begin{cases}
x_{n-1} + x_{n-2} \\
x_1 = x_0 = 1
\end{cases}
$$

$$
\Large
fib(n) =
\begin{cases}
x_{n-1} + x_{n-2} \\
x_0 = a \\
x_1 = b
\end{cases}
$$

$$
\Large
a\ b \\
a+b \\
a+2b \\
2a + 3b
$$

## Calcolo ricorsivo in C\#

La ricorsività è molto inefficiente perchè calcola ripetutamente gli stessi valori.

```csharp
static long Fib(int n)
{
    if (n == 1 || n == 2)
    {
        return 1;
    }

    return Fib(n - 1) + Fib(n - 2);
}
```

## Calcolo ricorsivo con elenco operazioni effettuate

```csharp
static long Fib2(int n, int livello = 0)
{
    // visualizza la profondità della ricorsione tramite gli spazi
    var spazi = new string(' ', livello * 4);

    Console.WriteLine($"{spazi}Fib({n}) chiamata");

    if (n == 1 || n == 2)
    {
        Console.WriteLine($"{spazi}Fib({n}) = 1");
        return 1;
    }

    long a = Fib2(n - 1, livello + 1);
    long b = Fib2(n - 2, livello + 1);

    long risultato = a + b;

    Console.WriteLine($"{spazi}Fib({n}) = Fib({n - 1}) + Fib({n - 2}) = {a} + {b} = {risultato}");

    return risultato;
}
```
