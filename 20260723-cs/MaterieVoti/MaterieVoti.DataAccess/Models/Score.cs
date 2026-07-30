namespace MaterieVoti.DataAccess.Models;

public class Score
{
    public int Id { get; init; }
    public int MateriaId { get; init; }
    public float Voto { get; set; }
    public DateTime DataInserimento { get; init; }
}
