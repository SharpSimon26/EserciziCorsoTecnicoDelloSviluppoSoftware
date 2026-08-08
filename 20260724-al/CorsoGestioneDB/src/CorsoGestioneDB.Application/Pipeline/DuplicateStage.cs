using CorsoGestioneDB.Application.Engine;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class DuplicateStage : StageBase
{
    public DuplicateStage(ILogger<DuplicateStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        throw new NotImplementedException();
    }
}