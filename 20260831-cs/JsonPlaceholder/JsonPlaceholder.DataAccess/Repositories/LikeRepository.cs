using Dapper;
using JsonPlaceholder.DataAccess.Database;
using JsonPlaceholder.DataAccess.Models.Entities;

namespace JsonPlaceholder.DataAccess.Repositories;

public class LikeRepository : AbstractRepository, ILikeRepository
{
    public LikeRepository(DbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }

    public async Task<IEnumerable<Like>> GetLikesByPhotoId(int photoId)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "select * from Likes where PhotoId = @photoId";
        var likes = await conn.QueryAsync<Like>(sql, new { photoId });

        return likes;
    }

    public async Task<int> AddLikeToPhoto(int photoId)
    {
        var conn = await connectionFactory.CreateConnection();
        var sql = "insert into Likes (PhotoId, UserId, DataInserimento) values (@photoId, @userId, @dataInserimento)";
        var userId = 1;
        var dataInserimento = DateTime.Now;
        var affectedRows = await conn.ExecuteAsync(sql, new { photoId, userId, dataInserimento });

        return affectedRows;
    }
}
