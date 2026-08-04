using TicTacToe.Web.Pages.Models;

namespace TicTacToe.Web.Services
{
    public interface IGameManager
    {
        List <GameTile> GameBoard { get; }
        bool IsActive { get; }
        string? WinnerName { get; }
        void GameMove(int id);
    }
}