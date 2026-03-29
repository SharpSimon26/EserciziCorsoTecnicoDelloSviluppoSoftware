Console.Write("Inserisci primo numero: ");
if (!decimal.TryParse(Console.ReadLine(), out decimal num1))
{
    Console.WriteLine("Errore: è richiesto un numero intero");
    Console.ReadLine();
    return;
}

Console.Write("Inserisci secondo numero: ");
if (!decimal.TryParse(Console.ReadLine(), out decimal num2))
{
    Console.WriteLine("Errore: è richiesto un numero intero");
    Console.ReadLine();
    return;
}

Console.Write("Quale operazione vuoi effettuare (+, -, *, /): ");
string? operazione = Console.ReadLine();
if (operazione == null)
{
    Console.WriteLine("Errore: definisci l'operazione da eseguire");
    Console.ReadLine();
    return;
}

decimal? risultato = null;

switch (operazione)
{
    case "+":
        risultato = num1 + num2;
        break;
    case "-":
        risultato = num1 - num2;
        break;
    case "*":
        risultato = num1 * num2;
        break;
    case "/":
        risultato = num1 / num2;
        break;
    default:
        Console.WriteLine("Errore: Operazione non riconosciuta");
        Console.ReadLine();
        return;
}

Console.WriteLine($"Il risultato è: {risultato}");
Console.ReadLine();