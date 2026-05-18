using ConsAppPunteggiGolf.Models;
using Spectre.Console;

var bucheGolfClubTrieste = new List<BucaInfo>()
{
    new() { Id =  1, Par = 4, Hcp =  3 },
    new() { Id =  2, Par = 5, Hcp = 11 },
    new() { Id =  3, Par = 4, Hcp = 14 },
    new() { Id =  4, Par = 4, Hcp =  7 },
    new() { Id =  5, Par = 3, Hcp = 13 },
    new() { Id =  6, Par = 4, Hcp =  5 },
    new() { Id =  7, Par = 4, Hcp = 17 },
    new() { Id =  8, Par = 4, Hcp =  1 },
    new() { Id =  9, Par = 4, Hcp =  9 },
    new() { Id = 10, Par = 3, Hcp =  8 },
    new() { Id = 11, Par = 4, Hcp = 10 },
    new() { Id = 12, Par = 3, Hcp = 14 },
    new() { Id = 13, Par = 5, Hcp = 12 },
    new() { Id = 14, Par = 4, Hcp =  6 },
    new() { Id = 15, Par = 3, Hcp = 16 },
    new() { Id = 16, Par = 4, Hcp = 18 },
    new() { Id = 17, Par = 4, Hcp =  4 },
    new() { Id = 18, Par = 4, Hcp =  2 }
};

// Handicap del giocatore
var hcpIndexGiocatore = await AnsiConsole.PromptAsync(new TextPrompt<int>("Inserisci HCP Index del Giocatore: ")
    .Validate(hcpIndexGiocatore =>
    {
        if (hcpIndexGiocatore < 1 && hcpIndexGiocatore > 54)
        {
            return ValidationResult.Error($"Inserisci un valore compreso tra 1 e 54");
        }

        return ValidationResult.Success(); 
    }));

// Buche
var numeroBuche = await AnsiConsole.PromptAsync(new TextPrompt<int>("Numero di buche da giocare: ")
    .Validate(numeroBuche =>
    {
        if (numeroBuche < 1 || numeroBuche > bucheGolfClubTrieste.Count)
        {
            return ValidationResult.Error($"Inserisci un valore compreso tra 1 e {bucheGolfClubTrieste.Count}");
        }

        return ValidationResult.Success();
    }));

var buchePartita = new List<Buca>(bucheGolfClubTrieste
                                    .Take(numeroBuche)
                                    .Select(m => new Buca()
                                        { 
                                            BucaId = m.Id,
                                            HandicapGiocatore = m.Par
                                        }
                                    )
                                );

if (numeroBuche >= 9)
{
    // Par assegnato a tutte le buche in base a HCP del giocatore
    var handicapDaDistribuire = (hcpIndexGiocatore / 18.0) * numeroBuche;
    Console.WriteLine($"Handicap da distribuire: {handicapDaDistribuire}");

    // Il Par del giocatore ad ogni buca viene aumentato di
    var colpiPerBuca = (int)handicapDaDistribuire / numeroBuche;
    Console.WriteLine($"Colpi per buca: {colpiPerBuca}");

    //  Punti extra da assegnare partendo dalla buca più difficile (hcp 1)
    var colpiExtraDaAssegnare = (int)handicapDaDistribuire % numeroBuche;
    Console.WriteLine($"Colpi extra da assegnare: {colpiExtraDaAssegnare}");

    // Somma a tutte le buche
    if (handicapDaDistribuire > 0)
    {
        foreach (var buca in buchePartita)
        {
            buca.HandicapGiocatore += colpiPerBuca;
        }
    }

    // Somma punti extra a specifiche buche
    if (colpiExtraDaAssegnare > 0)
    {
        var bucheDifficili = bucheGolfClubTrieste.OrderBy(m => m.Hcp).Take(colpiExtraDaAssegnare);
        foreach (var bucaD in bucheDifficili)
        {
            buchePartita.First(m => m.BucaId == bucaD.Id).HandicapGiocatore += 1;
        }
    }
}

// Ciclo per richiesta stroke su ogni buca
for (int i = 1; i <= numeroBuche; i++)
{
    var infoBucaCorrente = bucheGolfClubTrieste.First(m => m.Id == i);

    var strokes = await AnsiConsole.PromptAsync(new TextPrompt<int>($"Inserisci il numero di Stroke per la buca [red][bold]{i}[/][/]: ")
        .Validate(strokes =>
        {
            if (strokes < 1)
            {
                return ValidationResult.Error("Inserisci un valore superiore a 0");
            }

            return ValidationResult.Success();
        }));

    var bucaPartita = buchePartita.First(m => m.BucaId == infoBucaCorrente.Id);

    // Calcolo punteggio
    var punteggio = 2 + bucaPartita.HandicapGiocatore - strokes;
    if (punteggio < 0) { punteggio = 0; }
    bucaPartita.Punteggio = punteggio;

    AnsiConsole.WriteLine($"Buca: {i} - Par: {infoBucaCorrente.Par} - Par con Hcp: {bucaPartita.HandicapGiocatore} - Hcp buca: {infoBucaCorrente.Hcp} - Strokes: {strokes} - Punteggio: {punteggio}");
}

// Punteggio
var sommaPunteggi = buchePartita.Sum(m => m.Punteggio);

AnsiConsole.MarkupLine($"Somma punteggi per [red]{buchePartita.Count}[/] buche: [red]{sommaPunteggi}[/]");