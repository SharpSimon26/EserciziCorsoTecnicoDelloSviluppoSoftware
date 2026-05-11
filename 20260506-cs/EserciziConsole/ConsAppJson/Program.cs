using ConsAppJson.Clients;

//const string USERS_ENDPOINT = "https://jsonplaceholder.typicode.com/users";
//using HttpClient httpClient = new();
//var users = await httpClient.GetFromJsonAsync<List<User>>(USERS_ENDPOINT);

var users = (await UserClient.GetUsers()).OrderBy(m => m.Name);

if (users != null)
{
    foreach (var user in users)
    {
        Console.WriteLine("[{0}] \"{1}\" <{2}>", user.Id, user.Name, user.Email);
    }    
}
else
{
    Console.WriteLine("Nessun utente trovato");
}