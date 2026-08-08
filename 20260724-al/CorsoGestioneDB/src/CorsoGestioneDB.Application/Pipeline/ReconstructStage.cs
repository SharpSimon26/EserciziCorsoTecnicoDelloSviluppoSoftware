using CorsoGestioneDB.Application.Engine;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class ReconstructStage : StageBase
{
    public ReconstructStage(ILogger<ReconstructStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        throw new NotImplementedException();
    }
}