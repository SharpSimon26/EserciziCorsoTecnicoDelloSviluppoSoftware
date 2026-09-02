using Microsoft.AspNetCore.Mvc;
using Todo.DataAccess.DTO;
using Todo.DataAccess.Models.Entities;
using Todo.DataAccess.Repositories;

namespace Todo.Api.Endpoints.v1.Todos;

public static class TodoEndpointsV1
{
    public static IEndpointRouteBuilder MapTodoEndpointsV1(this IEndpointRouteBuilder app)
    {
        var todoGroup = app.MapGroup("/todos").WithTags("Todos");

        // GET ALL
        todoGroup.MapGet("/", async ([FromServices] ITodoRepository todoRepository) =>
        {
            var todos = await todoRepository.GetAllAsync();

            return TypedResults.Ok(todos);
        }).WithSummary("Get Todos"); //.Produces<IEnumerable<TodoItem>>(200);

        // GET ID
        todoGroup.MapGet("/{id}", async ([FromServices] ITodoRepository todoRepository, [FromRoute] int id) =>
        {
            var todo = await todoRepository.GetTodoByIdAsync(id);

            return todo == null
                ? Results.NotFound(new { message = "Todo non trovato" })
                : Results.Ok(todo);
        }).WithSummary("Get Todo by Id")
          .Produces<TodoItem>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound);

        // CREATE
        todoGroup.MapPost("/", async ([FromServices] ITodoRepository todoRepository, [FromBody] TodoCreateDTO dto) =>
        {
            var todo = await todoRepository.CreateTodoAsync(dto);

            return Results.Ok(todo);
        }).WithSummary("Create Todo")
          .Produces<TodoItem>(StatusCodes.Status200OK);

        // UPDATE (PUT)
        todoGroup.MapPut("/{id}", async ([FromServices] ITodoRepository todoRepository, [FromBody] TodoUpdateDTO dto, [FromRoute] int id) =>
        {
            // Le specifiche di PUT richiedono l'id da modificare nella Url
            if (await todoRepository.GetTodoByIdAsync(id) == null)
            {
                return Results.NotFound(new { message = "Todo non trovato" });
            }

            dto.Id = id;
            var todo = await todoRepository.UpdateTodoAsync(dto);

            return Results.Ok(todo);
        }).WithSummary("Update Todo")
          .Produces<TodoItem>(StatusCodes.Status200OK);

        // UPDATE (PATCH)
        todoGroup.MapPatch("/{id}", async ([FromServices] ITodoRepository todoRepository, [FromBody] TodoChangeDTO dto, [FromRoute] int id) =>
        {
            dto.Id = id;
            var todo = await todoRepository.ChangeTodoAsync(dto);

            return todo == null ? Results.NotFound(new { message = "Todo non trovato" }) : Results.Ok(todo);
        }).WithSummary("Update Todo (Done)")
          .Produces<TodoItem>(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound);

        // DELETE ID
        todoGroup.MapDelete("/{id}", async ([FromServices] ITodoRepository todoRepository, [FromRoute] int id) =>
        {
            var res = await todoRepository.DeleteTodoByIdAsync(id);

            return res ? Results.Ok(new { message = "Record eliminato" }) : Results.NotFound();
        }).WithSummary("Delete Todo")
          .Produces(StatusCodes.Status200OK)
          .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
