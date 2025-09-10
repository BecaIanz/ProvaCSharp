namespace ProvinhaCSharp.Services.JWT;

public interface IJWTService
{
    string CreateToken(ProfileToAuth data);
}