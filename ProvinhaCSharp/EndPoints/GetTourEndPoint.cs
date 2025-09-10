using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ProvinhaCSharp.EndPoints.DTO;
using ProvinhaCSharp.Services.ExtractJWTData;
using ProvinhaCSharp.UseCase;

namespace ProvinhaCSharp.EndPoints;

public static class GetTourEndPoint
{
    public static void ConfigureTourEndpoint(this WebApplication app)
    {

        //  Get de Tours
        app.MapGet("tours", async (
            [FromServices] GetTourUseCase useCase,
            [FromServices] EFExtractJWTData extractJWTData,
            HttpContext context
        ) =>

        {
            // Extract JWT
            var userID = await extractJWTData.GetUserGuid(context);
            if (userID is null)
                return Results.Unauthorized();

            var dto = new GetTourDTO(userID.Value);
            var result = await useCase.Do(dto);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok(result.Data);

        }).RequireAuthorization();
    }
}