using JsonPlaceholder.ApiClient.Models;

namespace JsonPlaceholder.ApiClient
{
    public interface IPhotosApiClient
    {
        Task<IEnumerable<Photo>> GetAllAsync();
    }
}