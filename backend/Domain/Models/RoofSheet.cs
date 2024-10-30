namespace Domain.Models;

public class RoofSheet
{
    public int RoofSheetId { get; set; }
    public string Name { get; set; }  // E.g., "Corrugated Sheet"
    public int RoofTypeId { get; set; }
    public RoofType RoofType { get; set; }
}
