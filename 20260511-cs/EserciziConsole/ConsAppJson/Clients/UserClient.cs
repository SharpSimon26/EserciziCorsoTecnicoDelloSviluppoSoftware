using ConsAppJson.Models;
using System.Net.Http.Json;

namespace ConsAppJson.Clients;

public static class UserClient
{
    private const string USERS_ENDPOINT = "https://jsonplaceholder.typicode.com/users";
    private const string USER_ENDPOINT = "https://jsonplaceholder.typicode.com/users/{id}";

    public static async Task<List<User>> GetUsers()
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<List<User>>(USERS_ENDPOINT) ?? [];
    }

    public static async Task<User?> GetUserById(int userId)
    {
        using HttpClient httpClient = new();
        return await httpClient.GetFromJsonAsync<User>(USER_ENDPOINT.Replace("{id}", userId.ToString()));
    }
}