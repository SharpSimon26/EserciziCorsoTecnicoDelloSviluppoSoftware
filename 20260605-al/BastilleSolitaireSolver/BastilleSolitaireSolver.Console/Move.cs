namespace BastilleSolitaireSolver.Models;

public class Move
{
    public int From { get; private set; }
    public int Jumped { get; private set; }
    public int To { get; private set; }

    public Move(int from, int jumped, int to)
    {
        From = from;
        Jumped = jumped;
        To = to;
    }

    public override string ToString()
    {
        return $"{From} -> {To} (salta {Jumped})";
    }
}