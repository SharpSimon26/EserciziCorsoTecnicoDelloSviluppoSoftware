using JsonPlaceholder.ApiClient.Models;
using System.Net.Http.Json;

namespace JsonPlaceholder.ApiClient;

public class PhotosApiClient : IPhotosApiClient
{
    private static readonly string jsonPlaceholderPhotosUrl = "https://jsonplaceholder.typicode.com/photos";

    public async Task<IEnumerable<Photo>> GetAllAsync()
    {
        using var client = new HttpClient();
        var photos = await client.GetFromJsonAsync<IEnumerable<Photo>>(jsonPlaceholderPhotosUrl) ?? [];

        return photos;
    }
}
