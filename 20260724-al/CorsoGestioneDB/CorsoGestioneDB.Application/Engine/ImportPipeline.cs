using CorsoGestioneDB.Application.Pipeline;

namespace CorsoGestioneDB.Application.Engine;

public class ImportPipeline
{
    private readonly NormalizeStage _normalize;

    /*
    private readonly ConvertStage _convert;

    private readonly DuplicateStage _duplicate;

    private readonly ValidationStage _validation;

    private readonly ReconstructionStage _reconstruction;

    private readonly ImportStage _import;

    private readonly LoggingStage _logging;
    */

    public ImportPipeline(NormalizeStage normalize)
    {
        _normalize = normalize;
    }

    public async Task ExecuteAsync(ImportContext context)
    {
        await _normalize.ExecuteAsync(context);

        /*
        if (context.StopPipeline)
        {
            await _logging.ExecuteAsync(context);
            return;
        }

        await _convert.ExecuteAsync(context);

        if (context.StopPipeline)
        {
            await _logging.ExecuteAsync(context);
            return;
        }
        */

        // ...
    }
}
