using ConsAppLinq.Models;

var users = new User[]
{
    new("Mario",    "Rossi",   1983, "Idraulico"),
    new("Luca",     "Verdi",   1983, "Pensionato"),
    new("Beppe",    "Viola",   1972, "Elettricista"),
    new("Lara",     "Gialli",  1998, "Avvocato"),
    new("Giulia",   "Bianchi", 1990, "Avvocato"),
    new("Carlo",    "Neri",    2012, "Sviluppatore"),
    new("Tancredi", "Grigi",   1935, "Pensionato"),
    new("Celeste",  "Azzurro", 1999, "Professore")
};

// estrai dall'array l'elenco delle professioni degli utenti minorenni
var professioniMinorenni = users.Where(m => m.BirthYear >= DateTime.Now.Year - 18)
                                .Select(x => x.Job);

foreach (var prof in professioniMinorenni)
{ 
    Console.WriteLine(prof);
}
