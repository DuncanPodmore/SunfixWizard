namespace SunFix.Models;

public class Client
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    
    public ICollection<Project> Projects { get; set; }
    public ICollection<Quote> Quotes { get; set; }
}
