using Dapper;
using Microsoft.Data.SqlClient;
using Spectre.Console;
using TreeConsole.Models;

var a = new Nodo { Label = "A" };
var b = new Nodo { Label = "B" };
var c = new Nodo { Label = "C" };
var d = new Nodo { Label = "D" };
var e = new Nodo { Label = "E" };
var f = new Nodo { Label = "F" };
var g = new Nodo { Label = "G" };
var h = new Nodo { Label = "H" };
var i = new Nodo { Label = "I" };
var l = new Nodo { Label = "L" };
var m = new Nodo { Label = "M" };

a.Children.AddRange(b, c);
b.Children.Add(d);
c.Children.Add(l);
b.Children.Add(e);
d.Children.Add(f);
e.Children.AddRange(g, h, i);

void ShowTree(Nodo root)
{
    var tree = new Spectre.Console.Tree(root.Label);

    foreach (var node in root.Children)
    {
        PopulateTree(tree, node);
    }

    AnsiConsole.Write(tree);
}

void PopulateTree(IHasTreeNodes treeNode, Nodo nodo)
{
    var tn = treeNode.AddNode(nodo.Label);

    foreach (var child in nodo.Children)
    {
        PopulateTree(tn, child);
    }
}

List<Nodo> GetChildrenByNodo(Nodo nodo, IEnumerable<TreeFlatItem> items)
{
    return nodo.Children = items.Where(x => x.ParentId == nodo.Id)
          .Select(x => x.ToNode())
          .ToList();
}

void BuildTree(Nodo nodo, IEnumerable<TreeFlatItem> items)
{
    nodo.Children = GetChildrenByNodo(nodo, items);

    foreach (var child in nodo.Children)
    {
        BuildTree(child, items);
    }
}

var connString = "Server=(localdb)\\MSSQLLocalDB;Database=PrimoDb;Integrated Security=True";

await using var conn = new SqlConnection(connString);
await conn.OpenAsync();

var sql = "select * from Albero";
var data = await conn.QueryAsync<TreeFlatItem>(sql);
var items = data.ToArray();

var inizio = items.Single(x => x.ParentId == null).ToNode();

BuildTree(inizio, items);

ShowTree(inizio);

Console.ReadLine();
