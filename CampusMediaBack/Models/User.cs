namespace CampusMediaBack.Models;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
    public string Role { get; set; } = "student";
    public List<int> Friends { get; set; } = new();
    public List<int> Suggestions { get; set; } = new();
    public List<Post> Posts { get; set; } = new();
    public List<Story> Stories { get; set; } = new();
}
