using ConsAppJson.Models;
using System.Net.Http.Json;

namespace ConsAppJson.Clients;

public static class UserClient
{
    private const string USERS_ENDPOINT = "https://jsonplaceholder.typicode.com/users";

    public static async Task<List<User>> GetUsers()
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<List<User>>(USERS_ENDPOINT) ?? [];
    }
}