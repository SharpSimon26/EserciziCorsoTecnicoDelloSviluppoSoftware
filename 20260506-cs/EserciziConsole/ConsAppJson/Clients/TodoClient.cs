using ConsAppJson.Models;
using System.Net.Http.Json;

namespace ConsAppJson.Clients;

public static class TodoClient
{
    private const string TODOS_ENDPOINT = "https://jsonplaceholder.typicode.com/todos";

    public static async Task<List<Todo>?> GetTodos()
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<List<Todo>>(TODOS_ENDPOINT);
    }
}