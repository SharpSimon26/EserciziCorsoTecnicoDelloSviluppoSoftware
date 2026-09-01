using JsonPlaceholder.Api.Models;
using JsonPlaceholder.DataAccess.Database;
using JsonPlaceholder.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

app.MapGet("/", () =>
{
    return new { message = "ciao a tutti!" };
});

app.MapPost("/somma", (Addendi addendi) =>
{
    return new { risultato = addendi.Addendo1 + addendi.Addendo2 };
});

app.MapPost("/calcolatrice", ([FromBody] Addendi addendi, [FromQuery] string operazione) =>
{
    decimal risultato = 0m;

    switch (operazione)
    {
        case "somma":
            risultato = addendi.Addendo1 + addendi.Addendo2;
            break;

        case "sottrazione":
            risultato = addendi.Addendo1 - addendi.Addendo2;
            break;

        case "moltiplicazione":
            risultato = addendi.Addendo1 * addendi.Addendo2;
            break;

        case "divisione":
            risultato = addendi.Addendo1 / addendi.Addendo2;
            break;

        default:
            return Results.BadRequest(new { message = "Operazione sconosciuta" });
    }

    return Results.Ok(risultato);

});

app.MapPost("/calcolatrice2", ([FromBody] Operazione operazione) =>
{
    try
    {
        var risultato = operazione.Execute();

        return Results.Ok(risultato);
    }
    catch (Exception)
    {
        return Results.BadRequest(new { message = "Operazione sconosciuta" });
    }
});

// ----------------------------------------------

var todos = new List<Todo>
{
    new() { Id = 1, Title = "fare la spesa", Done = false },
    new() { Id = 2, Title = "andare a Barcola", Done = true },
    new() { Id = 3, Title = "studiare C#", Done = false }
};


app.MapGet("/todos", () =>
{
    return Results.Ok(todos);
});

app.MapGet("/todos/{id}", ([FromRoute] int id) =>
{
    var todo = todos.FirstOrDefault(x => x.Id == id);

    if (todo != null)
    {
        return Results.Ok(todo);
    }
    else
    {
        return Results.NotFound(new { message = "Todo non trovato" });
    }
});

app.MapPost("/todos", async ([FromBody] Todo newTodo) =>
{
    todos.Add(new Todo { Title = newTodo.Title, Done = false });

    // INSERT INTO todos (label, done) VALUES ('Prova', false);
    // @@IDENTITY dentro una select restituisce l'ultimo id inserito
    /*
    var sql = @"
        INSERT INTO todos (label, done) VALUES (@title, false);
        SELECT id, label as title, done, FROM todos WHERE id = @@IDENTITY;
    ";
    var res = await connr.QuerySingleAsync<Todo>(sql, newTodo);
    */
    // SELECT id, label as title, done from todos where id = @@IDENTITY
    // return res != null
    //    ? Results.Created($"https://localhost:7022/todos/{res.Id}", res)
    //    : Results.BadRequest();

    return Results.Created();
});

// ----------------------------------------------

app.MapGet("/photos", async ([FromServices] IPhotosRepository photosRepository) =>
{
    var photos = await photosRepository.GetAllAsync();

    if (photos.Any())
    {
        return Results.Ok(photos);
    }
    else
    {
        return Results.NotFound(new { message = "Nessuna foto trovata" });
    }
});

app.MapGet("/photos/{id}", async ([FromServices] IPhotosRepository photosRepository, [FromRoute] int id) =>
{
    var photo = await photosRepository.GetPhotoById(id);

    if (photo != null)
    {
        return Results.Ok(photo);
    }
    else
    {
        return Results.NotFound(new { message = "Foto non trovata" });
    }
});

app.Run();

