using ProvinhaCSharp.Models;

namespace ProvinhaCSharp.UseCase;

public class EditTourUseCase(
    TourismAppDbContext ctx
)
{
    public async Task<Result<EditTourResponse>> Do(EditTourPayload payload)
    {
        //procura no banco
        var tour = await ctx.Tours.FindAsync(payload.TourId);

        //se for nulo da erro
        if (tour is null)
            return Result<EditTourResponse>.Fail("Tour not found!!");

        //se o usuario estiver tentando acessar uma tour que não é sua da erro
        if (tour.UserID != payload.UserID)
            return Result<EditTourResponse>.Fail("You do not have permission to access this tour!");
        
        //procura a atração no banco
        var attraction = await ctx.Attractions.FindAsync(payload.AttractionId);

        //se a atração nao existir da erro
        if (attraction is null)
            return Result<EditTourResponse>.Fail("Attraction not found!!");

        //se chegar aqui e nao quebrar no caminho ele adiciona a atração na lista de atrações no usuario
        tour.Attractions.Add(attraction);
        await ctx.SaveChangesAsync();

        return Result<EditTourResponse>.Success(null);

    }
}