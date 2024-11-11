using SunFix.Models;

namespace SunFix.Models;
public class Project
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public int ClientId { get; set; }
    public string Location { get; set; }

    public Client Client { get; set; }
    public ICollection<ContactInfo> ContactInfos { get; set; }
}
