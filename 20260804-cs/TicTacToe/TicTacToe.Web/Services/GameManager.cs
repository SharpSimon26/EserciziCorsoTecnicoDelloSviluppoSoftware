using System.Reflection.Metadata.Ecma335;
using TicTacToe.Web.Pages.Models;

namespace TicTacToe.Web.Services;

public class GameManager : IGameManager
{
    private const string Player1Name = "Player 1";
    private const string Player1Sign = "X";
    private const string Player2Name = "Player 2";
    private const string Player2Sign = "O";
    private bool Turn;  // true player 1 - false player 2

    public List<GameTile> GameBoard { get; private set; } = [];
    public bool IsActive { get; private set; }
    public string? WinnerName { get; private set; }

    public GameManager()
    {
        Turn = true;
        WinnerName = null;
        IsActive = true; // true se la partita è in corso, false se è finita
        InitializeBoard();
    }

    public void GameMove(int id)
    {
        var tile = GameBoard.FirstOrDefault(m => m.Id == id);

        if (tile != null && string.IsNullOrWhiteSpace(tile.Status) && IsActive)
        {
            tile.Status = Turn ? Player1Sign : Player2Sign;
            if (CheckForWin())
            {
                // Qualcuno ha vinto
                IsActive = false;
                WinnerName = Turn ? Player1Name : Player2Name;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(GameBoard[0].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[1].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[2].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[3].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[4].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[5].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[6].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[7].Status) &&
                    !string.IsNullOrWhiteSpace(GameBoard[8].Status))
                {
                    // Parità
                    IsActive = false;
                }

                // Cambio turno
                Turn = !Turn;
            }

        }
    }

    private bool CheckForWin()
    {
        // riga 1
        if (CheckTilesForWin(GameBoard[0], GameBoard[1], GameBoard[2]))
        {
            return true;
        }

        // riga 2
        if (CheckTilesForWin(GameBoard[3], GameBoard[4], GameBoard[5]))
        {
            return true;
        }

        // riga 3
        if (CheckTilesForWin(GameBoard[6], GameBoard[7], GameBoard[8]))
        {
            return true;
        }

        // colonna 1
        if (CheckTilesForWin(GameBoard[0], GameBoard[3], GameBoard[6]))
        {
            return true;
        }

        // colonna 2
        if (CheckTilesForWin(GameBoard[1], GameBoard[4], GameBoard[7]))
        {
            return true;
        }

        // colonna 3
        if (CheckTilesForWin(GameBoard[2], GameBoard[5], GameBoard[8]))
        {
            return true;
        }

        // diagonale 1
        if (CheckTilesForWin(GameBoard[0], GameBoard[4], GameBoard[8]))
        {
            return true;
        }

        // diagonale 2
        if (CheckTilesForWin(GameBoard[2], GameBoard[4], GameBoard[6]))
        {
            return true;
        }

        // Non ci sono combinazioni vincenti
        return false;
    }

    private static bool CheckTilesForWin(GameTile tile1, GameTile tile2, GameTile tile3)
    {
        if (string.IsNullOrWhiteSpace(tile1.Status) || string.IsNullOrWhiteSpace(tile2.Status) || string.IsNullOrWhiteSpace(tile3.Status))
        {
            return false;
        }

        if (string.Equals(tile1.Status, tile2.Status) && string.Equals(tile2.Status, tile3.Status))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InitializeBoard()
    {
        GameBoard = [];

        for (int i = 0; i < 9; i++)
        {
            GameBoard.Add(new GameTile() { Id = i + 1 });
        }
    }
}
