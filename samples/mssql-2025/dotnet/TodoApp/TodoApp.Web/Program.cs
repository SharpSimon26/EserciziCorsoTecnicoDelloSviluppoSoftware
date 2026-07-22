using TodoApp.DataAccess;
using TodoApp.DataAccess.Models;
using TodoApp.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mssqlDbSettings = builder.Configuration.GetRequiredSection("MSSqlDbSettings").Get<MSSqlDbSettings>() ??
    throw new InvalidOperationException("Impossibile trovare i dati per l'accesso al database");

// Add services to the container.
builder.Services.AddSingleton(new DbConnectionFactory(mssqlDbSettings));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

await app.RunAsync();
