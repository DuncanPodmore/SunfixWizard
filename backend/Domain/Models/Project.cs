namespace Domain.Models;

public class Project
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public List<Quote> Quotes { get; set; } = new();
}