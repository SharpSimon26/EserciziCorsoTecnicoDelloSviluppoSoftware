namespace Lib101;

public class Utils
{
    public static int Somma(params int[] addendi)
    {
        // params consente di non passare un array di interi quando si chiama il metodo
        // sintassi facilitata per chiamare questo metodo -> Utils.Somma(10, 15, 23);
        return addendi.Sum();
    }

    public static int Media(params int[] valori)
    {
        return valori.Sum() / valori.Length;
    }

    public static int SommaAge(User[] utenti)
    {
        return utenti.Sum(m => m.Age);
    }
}

public class User
{
    public required string Username { get; set; }
    public required int Age { get; set; }
}
