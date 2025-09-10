namespace ProvinhaCSharp.Services.ExtractJWTData;

public interface IExtractJWTData
{
    Task<Guid?> GetUserGuid(HttpContext context);

}