using System.ComponentModel.DataAnnotations;

namespace Di101.Web.Models;

public class RegisterForm
{
    [Required(ErrorMessage = "Compilare questo campo")]
    [MinLength(8)]
    public string Username { get; set; } = "";

    [Required]
    // [EmailAddress]
    [RegularExpression(@"^\w+@sito\.it$")]
    public string Email { get; set; } = "";

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = "";

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = "";
}
