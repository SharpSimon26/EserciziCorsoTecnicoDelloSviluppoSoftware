namespace ConsAppClassi;

internal class Utente(string nome, string cognome)
{
    public string Nome { get; set; } = nome;
    public string Cognome { get; set; } = cognome;
    public string FullName { 
        get { return $"{Nome} {Cognome}"; }
    }
}
