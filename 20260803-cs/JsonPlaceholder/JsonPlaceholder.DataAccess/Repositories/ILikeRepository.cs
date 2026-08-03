using JsonPlaceholder.DataAccess.Models.Entities;

namespace JsonPlaceholder.DataAccess.Repositories
{
    public interface ILikeRepository
    {
        Task<int> AddLikeToPhoto(int photoId);
        Task<IEnumerable<Like>> GetLikesByPhotoId(int photoId);
    }
}