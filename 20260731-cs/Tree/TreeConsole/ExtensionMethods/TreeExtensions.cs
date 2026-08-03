using TreeConsole.Models;

namespace TreeConsole.ExtensionMethods;

public static class TreeExtensions
{
	public static Nodo ToNode(this TreeFlatItem treeFlatItem)
	{
        return new Nodo()
        {
            Id = treeFlatItem.Id,
            Label = treeFlatItem.Label,
        };
    }
}
