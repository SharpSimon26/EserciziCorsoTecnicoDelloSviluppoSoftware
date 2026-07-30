using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaterieVoti.DataAccess.Repositories;
using MaterieVoti.Web.Forms;

namespace MaterieVoti.Web.Pages.Voti;

public class AddModel : PageModel
{
    private readonly IMaterieRepository _materieRepository;

    [BindProperty]
    public ScoreForm ScoreForm { get; set; }

    public AddModel(IMaterieRepository materieRepository)
    {
        _materieRepository = materieRepository;
        ScoreForm = new();
    }

    public async Task<IActionResult> OnGet(int id)
    {
        var materia = await _materieRepository.GetMateriaById(id);
        ScoreForm.MateriaId = id;

        return Page();
    }

    public async Task<IActionResult> OnPost(ScoreForm scoreForm)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _materieRepository.AddVoto(scoreForm.MateriaId, scoreForm.Voto, scoreForm.DataInserimento);

        return RedirectToPage("/Index");
    }
}
