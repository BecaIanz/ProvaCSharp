using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProvinhaCSharp.Models;
using ProvinhaCSharp.Services.JWT;
namespace ProvinhaCSharp.UseCase;

public class LoginUseCase(
    TourismAppDbContext ctx,
    IJWTService jwtService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        //pega o user do banco
        var user = await ctx.Users.FirstOrDefaultAsync(p => p.UserName == payload.Login || p.FullName == payload.Login);

        //se for da erro
        if (user is null)
            return Result<LoginResponse>.Fail("User not found!");
        
        //se a senha tiver errada da erro
        if (payload.Password != user.Password)
            return Result<LoginResponse>.Fail("Incorrect password");

        //cria um jwt com o serviço que eu fiz
        var jwt = jwtService.CreateToken(new(user.UserID, user.UserName));

        //se não quebrar no caminho vai chegar aqui e mandar o jwt/token como response
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}