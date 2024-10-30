namespace Domain.Models;

public class PartPreset
{
    public int PartPresetId { get; set; }
    public string Name { get; set; }
    public string RoofSheet { get; set; }
    public List<PartPresetItem> Parts { get; set; } = new();
}

public class PartPresetItem
{
    public int PartPresetItemId { get; set; }
    public int PartId { get; set; }
    public Part Part { get; set; }
    public int Quantity { get; set; }
}
