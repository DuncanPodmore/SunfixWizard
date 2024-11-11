namespace SunFix.Models;
public class QuotePart
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int QuoteId { get; set; }
    public int PartId { get; set; }
    public decimal PartQuotePrice { get; set; }
    public int Quantity { get; set; }

    public Quote Quote { get; set; }
    public Part Part { get; set; }
}
