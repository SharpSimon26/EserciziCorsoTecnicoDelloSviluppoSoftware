using JsonPlaceholder.DataAccess.Models.ViewModels;
using JsonPlaceholder.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JsonPlaceholder.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IPhotosRepository _photosRepository;

    public IEnumerable<PhotoWithLikesViewModel> Photos { get; set; }

    public IndexModel(IPhotosRepository photosRepository)
    {
        _photosRepository = photosRepository;
        Photos = [];
    }

    public async Task OnGet()
    {
        Photos = await _photosRepository.GetAllAsyncWithLikes();
    }
}
