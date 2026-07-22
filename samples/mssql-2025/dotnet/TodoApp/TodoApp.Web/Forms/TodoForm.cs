using System.ComponentModel.DataAnnotations;

namespace TodoApp.Web.Forms;

public class TodoForm
{
    public int Id { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    public bool Done { get; set; }
}