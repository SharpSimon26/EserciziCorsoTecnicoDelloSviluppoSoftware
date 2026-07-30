using Dapper;
using MaterieVoti.DataAccess.Models;
using MaterieVoti.DataAccess.Models.ViewModels;

namespace MaterieVoti.DataAccess.Repositories;

public class MaterieRepository : IMaterieRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public MaterieRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Subject>> GetMaterie()
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "select * from Materie order by Materia";
        var mats = await conn.QueryAsync<Subject>(sql);

        return mats;
    }

    public async Task<Subject?> GetMateriaById(int materiaId)
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "select * from Materie where Materia = @materiaId";
        var materia = await conn.QueryFirstOrDefaultAsync<Subject>(sql, new { materiaId });

        return materia;
    }

    public async Task<IEnumerable<Score>> GetVoti()
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "select * from Voti order by DataInserimento desc";
        var scores = await conn.QueryAsync<Score>(sql);

        return scores;
    }

    public async Task<IEnumerable<Score>> GetVotiByMateriaId(int materiaId)
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "select * from voti where MateriaId = @materiaId order by DataInserimento desc";
        var scores = await conn.QueryAsync<Score>(sql, new { materiaId });

        return scores;
    }

    public async Task<IEnumerable<SubjectWithScoresViewModel>> GetScores1()
    {
        var materie = await GetMaterie();
        var voti = await GetVoti();
        var materieConVoti = voti.Select(m => new SubjectWithScoresViewModel
        {
            IdVoto = m.Id,
            Materia = materie.First(r => r.Id == m.MateriaId).Materia,
            Voto = m.Voto,
            DataInserimento = DateOnly.FromDateTime(m.DataInserimento)
        })
        .OrderBy(m => m.Materia)
        .ThenBy(m => m.DataInserimento);

        return materieConVoti;
    }

    public async Task<IEnumerable<SubjectWithScoresViewModel2>> GetScores2()
    {
        var materie = await GetMaterie();
        var voti = await GetVoti();
        //var materieConAlmenoUnVoto = materie.Where(m => voti.Any(t => t.MateriaId == m.Id));

        var materieConVoti = materie.Select(m => new SubjectWithScoresViewModel2
        {
            IdMateria = m.Id,
            Materia = m.Materia,
            Scores = voti.Where(s => s.MateriaId == m.Id)
        });

        return materieConVoti;
    }

    public async Task<IEnumerable<SubjectWithScoresViewModel>> GetMaterieVoti()
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "select v.Id IdVoto, v.Voto, m.Materia, v.DataInserimento from Voti v INNER JOIN Materie m ON m.Id = v.MateriaId";
        var mats = await conn.QueryAsync<SubjectWithScoresViewModel>(sql);

        return mats;
    }

    public async Task<int> AddVoto(int materiaId, float voto, DateTime dataVoto)
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "insert into Voti (MateriaId, Voto, DataInserimento) values (@materiaId, @voto, @dataVoto)";
        var affectedRows = await conn.ExecuteAsync(sql, new { materiaId, voto, dataVoto });

        return affectedRows;
    }

    public async Task<int> UpdateVoto(int votoId, float voto, DateTime dataVoto)
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "update Voti set Voto = @voto, DataInserimento = @dataVoto where Id = @votoId";
        var affectedRows = await conn.ExecuteAsync(sql, new { voto, dataVoto, votoId });

        return affectedRows;
    }

    public async Task<int> DeleteVoto(int votoId)
    {
        var conn = await _connectionFactory.CreateConnection();
        var sql = "delete from Voti where Id = @votoId";
        var affectedRows = await conn.ExecuteAsync(sql, new { votoId });

        return affectedRows;
    }
}
