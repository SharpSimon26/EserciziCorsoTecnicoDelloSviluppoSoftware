using Sqlite.DataAccess;

var sqlite = new SqliteClient("sample.db");
var apples = await sqlite.GetApples();

if (apples.Any())
{
    foreach (var apple in apples)
    {
        Console.WriteLine($"Id:    {apple.Id}");
        Console.WriteLine($"Name:  {apple.Name}");
        Console.WriteLine($"Color: {apple.Color}");
        Console.WriteLine();
    }    
}
else
{
    Console.WriteLine("No apples found");
}
