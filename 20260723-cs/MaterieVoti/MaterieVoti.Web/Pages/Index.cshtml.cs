using MaterieVoti.DataAccess.Models.ViewModels;
using MaterieVoti.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaterieVoti.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IMaterieRepository _materieRepository;
    public IEnumerable<SubjectWithScoresViewModel2> Scores { get; set; }

    public IndexModel(IMaterieRepository materieRepository)
    {
        _materieRepository = materieRepository;
        Scores = [];
    }

    public async Task<IActionResult> OnGet()
    {
        Scores = await _materieRepository.GetScores2();

        return Page();
    }
}
