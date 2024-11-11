namespace SunFix.Models;
public class PartPreset
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }

    public ICollection<Part> Parts { get; set; }
}
