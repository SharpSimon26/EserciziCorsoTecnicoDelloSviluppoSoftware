using System.Numerics;
using BastilleSolitaireSolver.Models;

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

// centro della scacchiera
const int CENTER_INDEX = 22;

List<Move> AllMoves = [];

var numRows = map.GetLength(0);
var numCols = map.GetLength(1);

Console.WriteLine("Generazione elenco mosse possibili per la geometria della board...");

for (int row = 0; row < numRows; row++)
{
    for (int col = 0; col < numCols; col++)
    {
        if (map[row, col] > -1)
        {
            // Mossa su
            if (row-2 >= 0 && map[row-2, col] > -1)
            {
                AllMoves.Add(new Move(map[row, col], map[row-1, col], map[row-2, col]));
            }
            
            // Mossa a destra
            if (col+2 <= numCols-1 && map[row, col+2] > -1)
            {
                AllMoves.Add(new Move(map[row, col], map[row, col+1], map[row, col+2]));
            }

            // Mossa in basso
            if (row+2 <= numRows-1 && map[row+2, col] > -1)
            {
                AllMoves.Add(new Move(map[row, col], map[row+1, col], map[row+2, col]));
            }

            // Mossa a sinistra
            if (col-2 >= 0 && map[row, col-2] > -1)
            {
                AllMoves.Add(new Move(map[row, col], map[row, col-1], map[row, col-2]));
            }            
        }

    }
}

Console.WriteLine("Generazione completata. Inizio partita.");

ulong board = 0;

// Memoization
HashSet<ulong> visited = [];

// Lista mosse che portano alla soluzione
List<Move> solution = [];

// Dispone le pedine
for (int i = 0; i < 45; i++)
{
    board |= (1UL << i);
}

// Toglie la pedina centrale
board &= ~(1UL << CENTER_INDEX);

bool HasPeg(ulong board, int index)
{
    return (board & (1UL << index)) != 0;
}

bool IsValidMove(ulong board, Move move)
{
    // Se c'è una pedina nella casella di partenza e in quella intermedia ma non in quella 
    // di arrivo la mossa è valida
    return HasPeg(board, move.From) && HasPeg(board, move.Jumped) && !HasPeg(board, move.To);
}

ulong ApplyMove(ulong board, Move move)
{
    board &= ~(1UL << move.From);
    board &= ~(1UL << move.Jumped);
    board |= (1UL << move.To);

    return board;
}

bool IsSolved(ulong board)
{ 
    return BitOperations.PopCount(board) == 1 && HasPeg(board, CENTER_INDEX);
}

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

bool solved = Solve(board, solution);

Console.WriteLine("Partita completata.");

if (solved)
{
    foreach (var move in solution)
    {
        Console.WriteLine(move);
    }
}
else
{
    Console.WriteLine("Nessuna soluzione trovata");
}
