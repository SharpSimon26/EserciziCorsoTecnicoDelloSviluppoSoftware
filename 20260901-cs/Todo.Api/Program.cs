using Microsoft.AspNetCore.Mvc;
using Todo.DataAccess.Database;
using Todo.DataAccess.DTO;
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
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// GET ALL
app.MapGet("/todos", async ([FromServices] ITodoRepository todoRepository) =>
{
    var todos = await todoRepository.GetAllAsync();

    return Results.Ok(todos);
});

// GET ID
app.MapGet("/todos/{id}", async ([FromServices] ITodoRepository todoRepository, [FromRoute] int id) =>
{
    var todo = await todoRepository.GetTodoByIdAsync(id);

    return todo == null ? Results.NotFound(new { message = "Todo non trovato" }) : Results.Ok(todo);
});

// CREATE
app.MapPost("/todos", async ([FromServices] ITodoRepository todoRepository, [FromBody] TodoCreateDTO dto) =>
{
    var todo = await todoRepository.CreateTodoAsync(dto);

    return todo == null ? Results.NotFound(new { message = "Todo non creato" }) : Results.Ok(todo);
});

// UPDATE
app.MapPut("/todos/{id}", async ([FromServices] ITodoRepository todoRepository, [FromBody] TodoUpdateDTO dto, [FromRoute] int id ) =>
{
    // Le specifiche di PUT richiedono l'id da modificare nella Url
    dto.Id = id;
    var todo = await todoRepository.UpdateTodoAsync(dto);

    return todo == null ? Results.NotFound(new { message = "Todo non trovato" }) : Results.Ok(todo);
});

// UPDATE (done)
app.MapPatch("/todos", async ([FromServices] ITodoRepository todoRepository, [FromBody] TodoChangeDTO dto) =>
{
   var todo = await todoRepository.ChangeTodoAsync(dto);

    return todo == null ? Results.NotFound(new { message = "Todo non trovato" }) : Results.Ok(todo);
});

// DELETE ID
app.MapDelete("/todos/{id}", async ([FromServices] ITodoRepository todoRepository, [FromRoute] int id) =>
{
    var res = await todoRepository.DeleteTodoByIdAsync(id);

    return res ? Results.Ok(new { message = "Record eliminato" }) : Results.NotFound();
});

app.Run();
