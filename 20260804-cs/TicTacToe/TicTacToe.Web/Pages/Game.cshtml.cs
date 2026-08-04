using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicTacToe.Web.Services;

namespace TicTacToe.Web.Pages
{
    public class GameModel : PageModel
    {
        private IGameManager _gameManager;

        public GameModel(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public IActionResult OnGet(int id)
        {
            if (_gameManager.IsActive)
            {
                _gameManager.GameMove(id);
            }

            return RedirectToPage("Index");
        }
    }
}
