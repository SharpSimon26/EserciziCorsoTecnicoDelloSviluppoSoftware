namespace JsonPlaceholder.DataAccess.Models.Entities;

public class Like
{
    public int Id { get; set; }
    public int PhotoId { get; set; }
    public int UserId { get; set; }
    public DateTime DataInserimento { get; set; }
}
