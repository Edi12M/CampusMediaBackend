namespace CampusMediaBack.Models;

public class PostDetail
{
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;

    public string? Feeling { get; set; }
    public string? Location { get; set; }
}