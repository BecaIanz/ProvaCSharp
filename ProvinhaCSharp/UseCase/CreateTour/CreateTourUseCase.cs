using System.ComponentModel;
using ProvinhaCSharp.Models;
using ProvinhaCSharp.Services.ExtractJWTData;

namespace ProvinhaCSharp.UseCase;

public class CreateTourUseCase(
    TourismAppDbContext ctx,
    IExtractJWTData extractJWTData
)
{
    public async Task<Result<CreateTourResponse>> Do(CreateTourPayload payload)
    {
        //procura quem é o usuario que esta tentando criar a tour 
        var userID = await extractJWTData.GetUserGuid(payload.HttpContext);
        var user = await ctx.Users.FindAsync(userID);

        //cria a tour com os dados do payload
            var tour = new Tour
        {
            UserID = (Guid)userID,
            User = user,
            Title = payload.Title,
            Description = payload.Description
        };

        //adiciona na lista de tours do usuario
        user.Tours.Add(tour);
        await ctx.SaveChangesAsync();

        return Result<CreateTourResponse>.Success(new());
    }
}