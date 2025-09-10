namespace ProvinhaCSharp.UseCase;

public record EditTourPayload(
    Guid TourId,
    Guid AttractionId,
    Guid UserID
);