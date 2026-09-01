namespace Todo.DataAccess.DTO;

public class TodoUpdateDTO
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public bool Done { get; set; }
}