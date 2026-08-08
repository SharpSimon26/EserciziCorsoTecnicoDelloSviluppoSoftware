using CorsoGestioneDB.Application.Engine;

namespace CorsoGestioneDB.Application.Pipeline;

public interface IStage
{
    Task ExecuteAsync(ImportContext context);
}
