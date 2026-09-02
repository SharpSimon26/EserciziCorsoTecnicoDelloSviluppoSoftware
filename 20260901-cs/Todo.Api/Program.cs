using Scalar.AspNetCore;
using Todo.Api.Endpoints;
using Todo.DataAccess.Database;
using Todo.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // OpenAPI -> https://localhost:7208/openapi/v1.json
    app.MapOpenApi();

    // Scalar -> https://localhost:7208/scalar/v1
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
