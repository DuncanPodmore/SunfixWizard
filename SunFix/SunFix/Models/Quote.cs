namespace SunFix.Models;
public class Quote
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public int ClientId { get; set; }

    public Client Client { get; set; }
    public ICollection<QuotePart> QuoteParts { get; set; }
}
