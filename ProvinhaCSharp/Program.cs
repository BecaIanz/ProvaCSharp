using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProvinhaCSharp.Models;
using ProvinhaCSharp.Services.ExtractJWTData;
using ProvinhaCSharp.Services.JWT;
using ProvinhaCSharp.UseCase;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<TourismAppDbContext>(options =>
{
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

//serviços
builder.Services.AddTransient<IExtractJWTData, EFExtractJWTData>();
builder.Services.AddSingleton<IJWTService, JWTService>();

//useCases
builder.Services.AddTransient<CreateTourUseCase>();
builder.Services.AddTransient<EditTourUseCase>();
builder.Services.AddTransient<GetTourUseCase>();
builder.Services.AddTransient<LoginUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "ProvinhaCSharp", 
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

    
builder.Services.AddAuthentication(); // Config JWT
builder.Services.AddAuthorization(); // Config JWT


app.Run();
