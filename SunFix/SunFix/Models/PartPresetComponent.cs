namespace SunFix.Models;
public class PartPresetComponent
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int PartId { get; set; }
    public int PresetId { get; set; }
    public int QuantityOfPart { get; set; }

    public Part Part { get; set; }
    public PartPreset Preset { get; set; }
}
