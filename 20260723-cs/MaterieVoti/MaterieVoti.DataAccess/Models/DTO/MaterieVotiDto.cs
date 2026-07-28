namespace MaterieVoti.DataAccess.Models.DTO;

public class MaterieVotiDto
{
    public int IdVoto { get; set; }
    public string Materia { get; set; } = string.Empty;
    public float Voto { get; set; }
    public DateTime DataInserimento { get; set; }
}