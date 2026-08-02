using CorsoGestioneDB.Application.Engine;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class ConvertStage : StageBase
{
    public ConvertStage(ILogger<ConvertStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        throw new NotImplementedException();
    }
}