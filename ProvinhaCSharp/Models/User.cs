namespace ProvinhaCSharp.Models;

public class User
{
    public Guid UserID { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public ICollection<Tour> Tours { get; set; }
}