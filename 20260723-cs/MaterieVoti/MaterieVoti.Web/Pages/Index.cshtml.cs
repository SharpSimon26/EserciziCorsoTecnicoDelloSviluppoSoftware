using MaterieVoti.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaterieVoti.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IMaterieRepository _materieRepository;

    public IndexModel(IMaterieRepository materieRepository)
    {
        _materieRepository = materieRepository;
    }

    public async Task<IActionResult> OnGet()
    {
        var mats = await _materieRepository.GetMaterieVoti();

        return Page();
    }
}
