using Microsoft.AspNetCore.Mvc;
using ProvinhaCSharp.UseCase;

namespace ProvinhaCSharp.EndPoints;

public static class AuthEndPoint
{
    public static void ConfigureAuthEndpoint(this WebApplication app)
    {
        // Auntenticação
        app.MapPost("auth", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });
    }
}