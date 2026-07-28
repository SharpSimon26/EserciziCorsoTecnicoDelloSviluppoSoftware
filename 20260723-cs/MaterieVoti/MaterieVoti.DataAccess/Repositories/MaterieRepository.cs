using MaterieVoti.DataAccess.Models.DTO;
using Dapper;

namespace MaterieVoti.DataAccess.Repositories;

public class MaterieRepository : IMaterieRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public MaterieRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<MaterieVotiDto>> GetMaterieVoti()
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "select v.Id IdVoto, v.Voto, m.Materia, v.DataInserimento from Voti v INNER JOIN Materie m ON m.Id = v.MateriaId";
        var mats = await conn.QueryAsync<MaterieVotiDto>(sql);

        return mats;
    }
}
