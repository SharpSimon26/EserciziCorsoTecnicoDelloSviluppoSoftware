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
        // 1. Normalize
        await _normalize.ExecuteAsync(context);

        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        // 2. Convert
        await _convert.ExecuteAsync(context);

        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        // 3. Duplicate
        await _duplicate.ExecuteAsync(context);

        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        // 4. Validate
        await _validate.ExecuteAsync(context);

        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        // 5. Reconstruct
        await _reconstruct.ExecuteAsync(context);
        
        if (context.IsRejected)
        {
            await _log.ExecuteAsync(context);
            return;
        }

        // 6. Import
        await _import.ExecuteAsync(context);

        // 7. Log
        await _log.ExecuteAsync(context);
    }
}
