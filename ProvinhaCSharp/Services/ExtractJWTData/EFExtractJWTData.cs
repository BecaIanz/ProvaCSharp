using System.Security.Claims;
using ProvinhaCSharp.Models;

namespace ProvinhaCSharp.Services.ExtractJWTData;

public class EFExtractJWTData(TourismAppDbContext ctx) : IExtractJWTData
{
    public async Task<Guid?> GetUserGuid(HttpContext context)
    {
        var claim = context.User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim is null)
            return null;
        var id = Guid.Parse(claim.Value);
        return id;
    }
}