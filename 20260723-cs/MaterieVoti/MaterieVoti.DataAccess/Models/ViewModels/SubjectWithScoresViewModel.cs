namespace MaterieVoti.DataAccess.Models.ViewModels;

public class SubjectWithScoresViewModel
{
    public int IdVoto { get; set; }
    public string Materia { get; set; } = string.Empty;
    public float Voto { get; set; }
    public DateOnly DataInserimento { get; set; }
}