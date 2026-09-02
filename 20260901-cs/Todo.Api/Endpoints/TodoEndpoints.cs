using Todo.Api.Endpoints.v1.Todos;

namespace Todo.Api.Endpoints;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        var apiGroup = app.MapGroup("/api");
        var v1Group = apiGroup.MapGroup("/v1");
        var v2Group = apiGroup.MapGroup("/v2");
            
        v1Group.MapTodoEndpointsV1();

        return app;
    }
}