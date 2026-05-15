using ConsAppLeggiFiles.Models;

var folderPath = "Contents";
var currentDir = Directory.GetCurrentDirectory();
var files = Directory.GetFiles(Path.Join(currentDir, folderPath), "*.txt");

if (files.Any())
{
    var fileItems = await Task.WhenAll(files.Select(async filePath =>
    {
        var fileName = Path.GetFileName(filePath);
        var numLines = -1;

        try
        {
            numLines = (await File.ReadAllLinesAsync(filePath)).Length;
        }
        catch (Exception) { /* Intercetta eventuali eccezioni */ }
     
        return new FileItem() { FileName = fileName, NumLines = numLines };
    }));

    foreach (var item in fileItems)
    {
        Console.WriteLine(item.FileName + " - " + item.NumLines + " lines");
    }
}
else
{
    Console.WriteLine("La cartella non contiene files .txt");
}