using Di101.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Di101.Web.Pages.Calcolatrice;

public class CalcolatriceModel : PageModel
{
    [BindProperty]
    public CalcolatriceForm CalcolatriceForm { get; set; }

    public int? Somma { get; set; }

    public CalcolatriceModel()
    {
        var frm = new CalcolatriceForm();
        CalcolatriceForm = frm;
    }

    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            var v1 = CalcolatriceForm.Valore1;
            var v2 = CalcolatriceForm.Valore2;

            Somma = v1 + v2;            
        }
    }
}
