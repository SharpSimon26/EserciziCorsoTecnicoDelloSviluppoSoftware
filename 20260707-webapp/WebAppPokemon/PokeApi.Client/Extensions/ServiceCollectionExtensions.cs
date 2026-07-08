using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using PokeApi.Client.Services;

namespace PokeApi.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPokeApiClient(this IServiceCollection services, string baseAddress)
    {
        services.AddHttpClient<PokeApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            PropertyNameCaseInsensitive = true
        });

        return services;
    }
}