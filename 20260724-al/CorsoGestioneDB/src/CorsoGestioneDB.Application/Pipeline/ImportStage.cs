using CorsoGestioneDB.Application.Engine;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class ImportStage : StageBase
{
    public ImportStage(ILogger<ImportStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        throw new NotImplementedException();
    }
}