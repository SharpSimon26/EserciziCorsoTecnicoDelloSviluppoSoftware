using Di101.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Di101.Web.Pages.Register;

public class RegisterModel : PageModel
{
    [BindProperty]
    public RegisterForm Input { get; set; } = new();

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            var i = 2;
        }

        var x = 3;
    }
}
