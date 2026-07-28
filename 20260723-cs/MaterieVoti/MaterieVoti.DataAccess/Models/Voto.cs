namespace MaterieVoti.DataAccess.Models;

public class Voto
{
    public int Id { get; init; }
    public int MateriaId { get; init; }
    public float Votazione { get; set; }
    public DateOnly DataInserimento { get; init; }
}
