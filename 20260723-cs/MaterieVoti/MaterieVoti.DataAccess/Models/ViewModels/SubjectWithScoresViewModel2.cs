namespace MaterieVoti.DataAccess.Models.ViewModels;

public class SubjectWithScoresViewModel2
{
    public int IdMatera { get; set; }
    public string Materia { get; set; } = string.Empty;
    public float Media
    {
        get
        {
            if (Scores.Any())
            {
                return Scores.Sum(m => m.Voto) / Scores.Count();
            }
            else
            {
                return 0;
            }
        }
    }

    public IEnumerable<Score> Scores { get; set; } = [];
}