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

        return services;
    }
}
