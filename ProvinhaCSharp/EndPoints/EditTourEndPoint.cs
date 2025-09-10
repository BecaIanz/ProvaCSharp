using Microsoft.AspNetCore.Mvc;
using ProvinhaCSharp.UseCase;

namespace ProvinhaCSharp.EndPoints;

public static class EditTourEndPoint
{
    public static void EditTourEndpoint(this WebApplication app)
    {
        // Editar Tour
        app.MapPut("edit-tour/{userGuid}", async (
            [FromServices] EditTourUseCase useCase,
            [FromBody] EditTourPayload payload
        ) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        }).RequireAuthorization();
    }
}