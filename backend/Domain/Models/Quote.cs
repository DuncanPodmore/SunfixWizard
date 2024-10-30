namespace Domain.Models;

public class Quote
{
    public int QuoteId { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public decimal TotalCost { get; set; }
    public string PartsSnapshot { get; set; } // Stores immutable JSON of parts used.
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; } = true;  // Soft delete indicator.
}
