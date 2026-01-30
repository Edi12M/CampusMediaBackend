namespace CampusMediaBack.Models;
public class Post
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public List<int> Likes { get; set; } = new();
}
