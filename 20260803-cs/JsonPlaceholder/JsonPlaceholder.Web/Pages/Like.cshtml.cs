using JsonPlaceholder.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonPlaceholder.Web.Pages;

public class LikeModel : PageModel
{
    private readonly ILikeRepository _likeRepository;

    public LikeModel(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<IActionResult> OnGet(int Id)
    {
        await _likeRepository.AddLikeToPhoto(Id);

        return RedirectToPage("Index");
    }
}
