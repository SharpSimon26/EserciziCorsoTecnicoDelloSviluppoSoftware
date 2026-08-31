using JsonPlaceholder.DataAccess.Models.Entities;
using JsonPlaceholder.DataAccess.Models.ViewModels;

namespace JsonPlaceholder.DataAccess.Repositories;

public interface IPhotosRepository
{
    Task<IEnumerable<Photo>> GetAllAsync();
    Task<IEnumerable<PhotoWithLikesViewModel>> GetAllAsyncWithLikes();
    Task<Photo?> GetPhotoById(int id);
    Task<int> AddPhoto(int id, int albumId, string title, string url, string thumbnailUrl);
    Task<int> UpdatePhoto(int id, int albumId, string title, string url, string thumbnailUrl);
    Task<int> DeletePhotoById(int id);
}