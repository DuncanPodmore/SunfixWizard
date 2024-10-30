namespace Domain.Models;

public class Part
{
    public int PartId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // E.g., bolt, rail, etc.
    public decimal Price { get; set; }
}
