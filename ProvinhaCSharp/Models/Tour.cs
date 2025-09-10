namespace ProvinhaCSharp.Models;

public class Tour
{
    public Guid ID { get; set; }
    public Guid UserID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public User User { get; set; }
    public ICollection<Attractions> Attractions { get; set; } = [];
}