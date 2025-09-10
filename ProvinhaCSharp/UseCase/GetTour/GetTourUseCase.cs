using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProvinhaCSharp.EndPoints.DTO;
using ProvinhaCSharp.Models;

namespace ProvinhaCSharp.UseCase;

public class GetTourUseCase(
    TourismAppDbContext ctx
)
{
    public async Task<Result<GetTourResponse>> Do(GetTourDTO dto)
    {
        //procura no banco
        var tour = await ctx.Tours.FindAsync(dto.TourId);

        //se for nulo retorna erro
        if (tour is null)
            return Result<GetTourResponse>.Fail("Tour not found!!");

        return Result<GetTourResponse>.Success(new(tour));
    }
}