using ConsAppJson.Clients;

//const string USERS_ENDPOINT = "https://jsonplaceholder.typicode.com/users";
//using HttpClient httpClient = new();
//var users = await httpClient.GetFromJsonAsync<List<User>>(USERS_ENDPOINT);

var users = (await UserClient.GetUsers()).OrderBy(m => m.Name);
var todos = await TodoClient.GetTodos();

if (todos.Any())
{
    foreach (var todo in todos)
    {
        // Single funziona come First ma genera un'eccezione se trova più di un elemento
        var user = users.FirstOrDefault(m => m.Id == todo.UserId);
        var completato = todo.Completed ? "Completato" : "Non completato";
        Console.WriteLine("[{0}] \"{1}\" <{2}>", user?.Name ?? "Sconosciuto", todo.Title, completato);
    }    
}
else
{
    Console.WriteLine("Nessun Todo trovato");
}