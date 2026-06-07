# Bastille Solitaire 44 pedine

## Mappa della scacchiera

Array bidimensionale di interi utilizzato per generare l'elenco di mosse possibili

``` csharp
int[,] map =
{
  { -1, -1, -1,  0,  1,  2, -1, -1, -1 },
  { -1, -1, -1,  3,  4,  5, -1, -1, -1 },
  { -1, -1, -1,  6,  7,  8, -1, -1, -1 },
  {  9, 10, 11, 12, 13, 14, 15, 16, 17 },
  { 18, 19, 20, 21, 22, 23, 24, 25, 26 },
  { 27, 28, 29, 30, 31, 32, 33, 34, 35 },
  { -1, -1, -1, 36, 37, 38, -1, -1, -1 },
  { -1, -1, -1, 39, 40, 41, -1, -1, -1 },
  { -1, -1, -1, 42, 43, 44, -1, -1, -1 }
};
```

## Posizione delle pedine sulla board

```csharp
ulong board = 0;
```

Per minimizzare il consumo di ram viene utilizzato un long senza segno a 64 bit (bitboard) per contenere le pedine e la loro posizione.

## Bitwise operations

I movimenti delle pedine sono registrati modificando direttamente i bit della board.

```csharp
ulong ApplyMove(ulong board, Move move)
{
    board &= ~(1UL << move.From);
    board &= ~(1UL << move.Jumped);
    board |= (1UL << move.To);

    return board;
}
```

## Solver basato su funzione ricorsiva e Depth First Search (DFS)

Il solver tenta tutte le mosse valide, una alla volta, richiamandosi ricorsivamente e tenendo traccia dei tentativi fatti. Quando esaurisce le mosse valide torna automaticamente indietro e prova altre mosse.

```csharp
bool Solve(ulong board, List<Move> path)
{
    if (IsSolved(board))
    {
        return true;
    }

    if (visited.Contains(board))
    {
        return false;
    }

    visited.Add(board);

    foreach (var move in AllMoves)
    {
        if (!IsValidMove(board, move))
        {
            continue;
        }

        var newBoard = ApplyMove(board, move);

        path.Add(move);

        if (Solve(newBoard, path))
        {
            return true;
        }

        path.RemoveAt(path.Count -1);
    }

    return false;
}
```

## Output del programma

```bash
Generazione elenco mosse possibili per la geometria della board...
Generazione completata. Inizio partita.
Partita completata.
7 -> 22 (salta 13)
1 -> 7 (salta 4)
11 -> 13 (salta 12)
3 -> 12 (salta 6)
8 -> 6 (salta 7)
2 -> 8 (salta 5)
9 -> 11 (salta 10)
12 -> 3 (salta 6)
0 -> 6 (salta 3)
14 -> 5 (salta 8)
16 -> 14 (salta 15)
13 -> 15 (salta 14)
27 -> 9 (salta 18)
28 -> 10 (salta 19)
10 -> 12 (salta 11)
21 -> 19 (salta 20)
30 -> 28 (salta 29)
28 -> 10 (salta 19)
9 -> 11 (salta 10)
11 -> 13 (salta 12)
22 -> 7 (salta 13)
6 -> 8 (salta 7)
5 -> 14 (salta 8)
14 -> 16 (salta 15)
17 -> 15 (salta 16)
24 -> 22 (salta 23)
26 -> 24 (salta 25)
39 -> 30 (salta 36)
38 -> 36 (salta 37)
22 -> 37 (salta 31)
30 -> 39 (salta 36)
42 -> 36 (salta 39)
44 -> 38 (salta 41)
32 -> 41 (salta 38)
34 -> 32 (salta 33)
15 -> 33 (salta 24)
32 -> 34 (salta 33)
35 -> 33 (salta 34)
36 -> 38 (salta 37)
41 -> 32 (salta 38)
33 -> 31 (salta 32)
43 -> 37 (salta 40)
37 -> 22 (salta 31)
```
