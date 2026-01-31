namespace CampusMediaBack.Models;

public class UserProfile
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string Bio { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
}