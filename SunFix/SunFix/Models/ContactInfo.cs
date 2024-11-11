namespace SunFix.Models;
public class ContactInfo
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int ClientId { get; set; }
    public int ProjectId { get; set; }

    public Client Client { get; set; }
    public Project Project { get; set; }
}
