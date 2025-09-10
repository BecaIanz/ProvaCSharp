namespace ProvinhaCSharp.Models;

public class Tour
{
    public Guid TourID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    ICollection<Attractions> Attractions { get; set; }
}