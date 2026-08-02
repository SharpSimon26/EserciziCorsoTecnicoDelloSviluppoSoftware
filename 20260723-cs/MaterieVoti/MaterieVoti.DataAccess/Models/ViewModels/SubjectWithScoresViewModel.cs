namespace MaterieVoti.DataAccess.Models.ViewModels;

public class SubjectWithScoresViewModel
{
    public int IdMateria { get; set; }
    public int IdVoto { get; set; }
    public string Materia { get; set; } = string.Empty;
    public float? Voto { get; set; }
    public DateTime? DataInserimento { get; set; }
}