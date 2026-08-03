using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JsonPlaceholder.ApiClient;
using JsonPlaceholder.Console;
using JsonPlaceholder.DataAccess.Database;
using JsonPlaceholder.DataAccess.Repositories;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                     .AddUserSecrets<Program>();

builder.Services.AddScoped<DbConnectionFactory>();
builder.Services.AddScoped<ImportEngine>();
builder.Services.AddScoped<IPhotosApiClient, PhotosApiClient>();
builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();

using var host = builder.Build();

await host.Services
    .GetRequiredService<ImportEngine>()
    .RunAsync();
