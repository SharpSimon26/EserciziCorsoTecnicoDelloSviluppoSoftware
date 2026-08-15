using CorsoGestioneDB.Application.Pipeline;

namespace CorsoGestioneDB.Application.Engine;

public class ImportPipeline
{
    private readonly NormalizeStage _normalize;
    private readonly DuplicateStage _duplicate;    
    private readonly ConvertStage _convert;
    private readonly ValidateStage _validate;
    private readonly ReconstructStage _reconstruct;
    private readonly ImportStage _import;
    private readonly LogStage _log;

    public ImportPipeline(NormalizeStage normalize, DuplicateStage duplicate, ConvertStage convert,
        ValidateStage validate, ReconstructStage reconstruct, ImportStage import, LogStage log)
    {
        _normalize = normalize;
        _duplicate = duplicate;        
        _convert = convert;
        _validate = validate;
        _reconstruct = reconstruct;
        _import = import;
        _log = log;
    }

    public async Task ExecuteAsync(IEnumerable<ImportContext> contexts)
    {
        // 1. Normalize
        await _normalize.ExecuteAsync(contexts);

        // 2. Duplicate
        await _duplicate.ExecuteAsync(contexts.Where(x => x.IsProcessable()).ToList());

        // 3. Convert
        await _convert.ExecuteAsync(contexts.Where(x => x.IsProcessable()).ToList());

        // 4. Validate
        await _validate.ExecuteAsync(contexts.Where(x => x.IsProcessable()).ToList());

        // 5. Reconstruct
        await _reconstruct.ExecuteAsync(contexts.Where(x => x.IsProcessable()).ToList());

        // 6. Import
        await _import.ExecuteAsync(contexts.Where(x => x.IsReady()).ToList());

        // 7. Log
        await _log.ExecuteAsync(contexts.ToList());
    }
}
