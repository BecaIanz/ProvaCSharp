using System.ComponentModel.DataAnnotations;

namespace ProvinhaCSharp.UseCase;

public record CreateTourPayload
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }

    [Required]
    [MinLength(40)]
    [MaxLength(200)]
    public string Description { get; set; }

    public HttpContext HttpContext;

}