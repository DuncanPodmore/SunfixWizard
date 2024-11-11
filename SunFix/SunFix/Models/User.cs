namespace SunFix.Models;

public class User
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsAdmin { get; set; }
    public string Email { get; set; }
}