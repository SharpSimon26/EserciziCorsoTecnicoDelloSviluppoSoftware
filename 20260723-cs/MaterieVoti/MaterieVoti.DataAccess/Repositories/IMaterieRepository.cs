using MaterieVoti.DataAccess.Models;
using MaterieVoti.DataAccess.Models.ViewModels;

namespace MaterieVoti.DataAccess.Repositories;

public interface IMaterieRepository
{
    Task<IEnumerable<SubjectWithScoresViewModel>> GetMaterieVoti();
    Task<IEnumerable<SubjectWithScoresViewModel>> GetScores1();
    Task<IEnumerable<SubjectWithScoresViewModel2>> GetScores2();
    Task<IEnumerable<Subject>> GetMaterie();
    Task<Subject?> GetMateriaById(int materiaId);
    Task<int> AddVoto(int materiaId, float voto, DateTime dataVoto);
    Task<int> UpdateVoto(int votoId, float voto, DateTime dataVoto);
    Task<int> DeleteVoto(int votoId);
}