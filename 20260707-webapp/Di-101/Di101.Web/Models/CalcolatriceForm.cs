using System.ComponentModel.DataAnnotations;

namespace Di101.Web.Models;

public class CalcolatriceForm
{
    [Required(ErrorMessage = "Compilare questo campo")]
    [Range(int.MinValue, int.MaxValue, ErrorMessage = "Inserire un numero valido")]
    public int? Valore1 { get; set; }

    [Required(ErrorMessage = "Compilare questo campo")]
    [Range(int.MinValue, int.MaxValue, ErrorMessage = "Inserire un numero valido")]
    public int? Valore2 { get; set; }
}