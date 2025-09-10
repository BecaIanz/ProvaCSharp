namespace ProvinhaCSharp.UseCase;

public record LoginPayload(
    string Login,
    string Password
);