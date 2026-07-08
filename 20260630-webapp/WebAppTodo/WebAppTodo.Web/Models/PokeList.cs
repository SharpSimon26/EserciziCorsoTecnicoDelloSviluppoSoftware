namespace WebAppTodo.Web.Models;

public class PokeList
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public Result[] results { get; set; }
}
