namespace SunFix.Models;
public class Part
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int PresetId { get; set; }

    public PartPreset Preset { get; set; }
    public ICollection<QuotePart> QuoteParts { get; set; }
    public ICollection<PartPresetComponent> PartPresetComponents { get; set; }
}
