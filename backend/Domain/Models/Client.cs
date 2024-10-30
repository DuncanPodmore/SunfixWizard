namespace Domain.Models;

public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public string ContactEmail { get; set; }
    public string Phone { get; set; }
    public List<Project> Projects { get; set; } = new();
}
