using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrimoSitoWeb.Services;

namespace PrimoSitoWeb.Pages;

public class StudentsModel : PageModel
{
    public void OnGet(StudentiService studentiService)
    {
        var response = studentiService.GetStudenti();
    }
}
