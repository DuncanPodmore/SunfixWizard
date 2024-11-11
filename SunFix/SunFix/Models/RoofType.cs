namespace SunFix.Models;

public class RoofType
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }

    public ICollection<RoofSheet> RoofSheets { get; set; }
}
