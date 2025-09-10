using Microsoft.AspNetCore.Mvc;
using ProvinhaCSharp.UseCase;

namespace ProvinhaCSharp.EndPoints;

public static class CreateTourEndPoint
{
    public static void ConfigureTourEndpoint(this WebApplication app)
    {
        //Criar Tour
        app.MapPost("create-tour", async (
            [FromServices] CreateTourUseCase useCase,
            [FromBody] CreateTourPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            
            return Results.Ok(result.Data);
            

        }).RequireAuthorization();
    }
}