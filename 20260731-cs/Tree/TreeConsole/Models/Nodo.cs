using System.Diagnostics;

namespace TreeConsole.Models;

[DebuggerDisplay("{Label}: {Children.Count} Children")]
public class Nodo
{
    public int Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public List<Nodo> Children { get; set; } = [];
}
