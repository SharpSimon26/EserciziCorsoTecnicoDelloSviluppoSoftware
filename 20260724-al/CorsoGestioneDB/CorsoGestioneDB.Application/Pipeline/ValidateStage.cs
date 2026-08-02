using CorsoGestioneDB.Application.Engine;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class ValidateStage : StageBase
{
    public ValidateStage(ILogger<ValidateStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        throw new NotImplementedException();
    }
}