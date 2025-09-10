namespace ProvinhaCSharp.Models;

public class Attractions
{
    public Guid ID { get; set; }
    public string AttractionName { get; set; }
    public ICollection<Tour> Tours { get; set; } = [];
}