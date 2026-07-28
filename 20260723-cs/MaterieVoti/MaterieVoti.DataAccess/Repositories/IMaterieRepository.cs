using MaterieVoti.DataAccess.Models.DTO;

namespace MaterieVoti.DataAccess.Repositories;

public interface IMaterieRepository
{
    Task<IEnumerable<MaterieVotiDto>> GetMaterieVoti();
}