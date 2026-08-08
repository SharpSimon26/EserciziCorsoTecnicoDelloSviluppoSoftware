using CorsoGestioneDB.Abstractions.Interfaces;

namespace CorsoGestioneDB.Application.Engine;

public class ImportEngine
{
    private readonly IStagingOrderRepository _stagingOrderRepository;
    private readonly ImportPipeline _pipeline;

    public ImportEngine(IStagingOrderRepository stagingOrderRepository, ImportPipeline pipeline)
    {
        _stagingOrderRepository = stagingOrderRepository;
        _pipeline = pipeline;
    }

    public async Task RunAsync()
    {
        var rows = await _stagingOrderRepository.GetAllAsync();

        foreach (var row in rows)
        {
            var context = new ImportContext(row);

            await _pipeline.ExecuteAsync(context);
        }
    }
}
