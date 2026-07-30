using MaterieVoti.DataAccess.Models.ViewModels;

namespace MaterieVoti.DataAccess.Repositories;

public interface IMaterieRepository
{
    Task<IEnumerable<SubjectWithScoresViewModel>> GetMaterieVoti();
    Task<IEnumerable<SubjectWithScoresViewModel>> GetScores1();
    Task<IEnumerable<SubjectWithScoresViewModel2>> GetScores2();
}