namespace CampusMediaBack.DTOs;
public class StoryDto
{
    public int Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public bool Viewed { get; set; }
}
