namespace TreeConsole.Models;

public class TreeFlatItem
{
    public int Id { get; set; }
    public string Label { get; set; }
    public int? ParentId { get; set; }

    public Nodo ToNode()
    {
        return new Nodo()
        {
            Id = Id,
            Label = Label,
        };
    }
}
