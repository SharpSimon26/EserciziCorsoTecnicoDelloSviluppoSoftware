using CorsoGestioneDB.Application.Pipeline;

namespace CorsoGestioneDB.Application.Engine;

public class ImportPipeline
{
    private readonly NormalizeStage _normalize;
    private readonly ConvertStage _convert;
    private readonly DuplicateStage _duplicate;
    private readonly ValidateStage _validate;
    private readonly ReconstructStage _reconstruct;
    private readonly ImportStage _import;
    private readonly LogStage _log;

    public ImportPipeline(NormalizeStage normalize, ConvertStage convert, DuplicateStage duplicate, 
        ValidateStage validate, ReconstructStage reconstruct, ImportStage import, LogStage log)
    {
        _normalize = normalize;
        _convert = convert;
        _duplicate = duplicate;
        _validate = validate;
        _reconstruct = reconstruct;
        _import = import;
        _log = log;
    }

    public async Task ExecuteAsync(ImportContext context)
    {
        await _normalize.ExecuteAsync(context);
        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        await _convert.ExecuteAsync(context);
        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        await _duplicate.ExecuteAsync(context);
        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        await _validate.ExecuteAsync(context);
        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        await _reconstruct.ExecuteAsync(context);
        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        await _import.ExecuteAsync(context);

        await _log.ExecuteAsync(context);
    }
}
