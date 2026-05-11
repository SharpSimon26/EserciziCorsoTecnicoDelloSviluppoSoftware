Console.WriteLine("Start...");
Console.WriteLine(await GetTheAnswerToLifeTheUniverseAndEverything());
Console.WriteLine("End.");


static async Task<string> GetTheAnswerToLifeTheUniverseAndEverything()
{
    // Task.Delay(5000).Wait(); .Wait blocca il thread
    // YT Async Programming Deep Dive
    // YT Approfondimento sula programmazione asincrona con Bart De Smet

    //Task t = Task.Delay(5000);
    //t.Wait();

    await Task.Delay(5000);
    return "42";
}
