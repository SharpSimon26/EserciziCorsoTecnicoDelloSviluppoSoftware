using Dapper;
using JsonPlaceholder.DataAccess.Database;
using JsonPlaceholder.DataAccess.Models.Entities;
using JsonPlaceholder.DataAccess.Models.ViewModels;

namespace JsonPlaceholder.DataAccess.Repositories;

public class PhotosRepository : AbstractRepository, IPhotosRepository
{
    public PhotosRepository(DbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<Photo>> GetAllAsync()
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "select * from photos order by Id";
        var photos = await conn.QueryAsync<Photo>(sql);

        return photos;
    }

    public async Task<IEnumerable<PhotoWithLikesViewModel>> GetAllAsyncWithLikes()
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "select ph.Id, ph.Title, (select count(*) from Likes where PhotoId = ph.Id) as NumLikes from Photos ph";
        var photos = await conn.QueryAsync<PhotoWithLikesViewModel>(sql);

        return photos;
    }

    public async Task<Photo?> GetPhotoById(int id)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "select * from photos where Id = @id";
        var photos = await conn.QueryFirstOrDefaultAsync<Photo>(sql, new { id });

        return photos;
    }

    public async Task<int> AddPhoto(int id, int albumId, string title, string url, string thumbnailUrl)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "insert into Photos (Id, AlbumId, Title, Url, ThumbnailUrl) values (@id, @albumId, @title, @url, @thumbnailUrl)";
        var affectedRows = await conn.ExecuteAsync(sql, new { id, albumId, title, url, thumbnailUrl });

        return affectedRows;
    }

    public async Task<int> UpdatePhoto(int id, int albumId, string title, string url, string thumbnailUrl)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "update Photos set AlbumId = @albumId, Title = @title, Url = @url, thumbnailUrl = @thumbnailUrl where Id = @id";
        var affectedRows = await conn.ExecuteAsync(sql, new { id, albumId, title, url, thumbnailUrl });

        return affectedRows;
    }

    public async Task<int> DeletePhotoById(int id)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "delete from Photos where Id = @id";
        var affectedRows = await conn.ExecuteAsync(sql, new { id });

        return affectedRows;
    }
}
