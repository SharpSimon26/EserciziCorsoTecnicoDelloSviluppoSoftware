using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicTacToe.Web.Pages.Models;
using TicTacToe.Web.Services;

namespace TicTacToe.Web.Pages;

public class IndexModel : PageModel
{
    private IGameManager _gameManager;
    public string? WinnerName;
    public bool IsActive;

    public List<GameTile> GameBoard { get; private set; } = [];

    public IndexModel(IGameManager gameManager)
    {
        _gameManager = gameManager;
        IsActive = gameManager.IsActive;
        WinnerName = string.Empty;
    }

    public void OnGet()
    {
        GameBoard = _gameManager.GameBoard;
        IsActive = _gameManager.IsActive;
        WinnerName = _gameManager.WinnerName;
    }
}
