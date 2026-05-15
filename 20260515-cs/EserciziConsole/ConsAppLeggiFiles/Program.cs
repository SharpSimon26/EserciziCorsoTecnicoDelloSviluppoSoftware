var folderPath = "Contents";
var currentDir = Directory.GetCurrentDirectory();
var files = Directory.GetFiles(Path.Join(currentDir, folderPath), "*.txt");

if (files.Any())
{
    var fileLines = new Dictionary<string, int>();

    await Task.WhenAll(files.Select(async filePath =>
    {
        var fileName = Path.GetFileName(filePath);

        try
        {
            var numLines = (await File.ReadAllLinesAsync(filePath)).Length;
            fileLines.TryAdd(fileName, numLines);
        }
        catch (Exception)
        {
            fileLines.TryAdd(fileName, -1);
        }
    }));

    foreach (var item in fileLines)
    {
        Console.WriteLine(item.Key + " - " + item.Value + " lines");
    }
}
else
{
    Console.WriteLine("La cartella non contiene files .txt");
}