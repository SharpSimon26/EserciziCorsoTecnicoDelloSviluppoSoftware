using CorsoGestioneDB.Application.Engine;
using CorsoGestioneDB.Application.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace CorsoGestioneDB.Application.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Registrazione dei repository dell'applicazione
        services.AddTransient<ImportEngine>();
        services.AddTransient<ImportPipeline>();

        services.AddTransient<NormalizeStage>();
        services.AddTransient<DuplicateStage>();
        services.AddTransient<ConvertStage>();
        services.AddTransient<ValidateStage>();
        services.AddTransient<ReconstructStage>();
        services.AddTransient<ImportStage>();
        services.AddTransient<LogStage>();

        return services;
    }
}
