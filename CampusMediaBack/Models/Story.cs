namespace CampusMediaBack.Models;
public class Story
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public List<int> ViewedBy { get; set; } = new();
}
