namespace Domain.Models;

public class RoofType
{
    public int RoofTypeId { get; set; }
    public string Name { get; set; }  // E.g., Trapezoidal, Flat, etc.
    public List<RoofSheet> RoofSheets { get; set; } = new();
}
