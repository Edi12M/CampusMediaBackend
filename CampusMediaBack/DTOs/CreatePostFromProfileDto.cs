namespace CampusMediaBack.DTOs;

public class CreatePostFromProfileDto
{
    public string Image { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string? Feeling { get; set; }
    public string? Location { get; set; }
}