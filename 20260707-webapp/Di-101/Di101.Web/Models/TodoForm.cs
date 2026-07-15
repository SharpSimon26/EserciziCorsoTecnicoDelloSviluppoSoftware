using System.ComponentModel.DataAnnotations;

namespace Di101.Web.Models;

public class TodoForm
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    public bool Done { get; set; }
}