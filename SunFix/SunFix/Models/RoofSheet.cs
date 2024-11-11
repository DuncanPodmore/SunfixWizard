namespace SunFix.Models;
public class RoofSheet
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public int RoofTypeId { get; set; }
    public int MidClampsPresetId { get; set; }
    public int EndClampsPresetId { get; set; }

    public RoofType RoofType { get; set; }
}
