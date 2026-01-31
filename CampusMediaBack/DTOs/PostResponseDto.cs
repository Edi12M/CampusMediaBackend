namespace CampusMediaBack.DTOs;

public class PostResponseDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string? Feeling { get; set; }
    public string? Location { get; set; }
    public List<CommentResponseDto> Comments { get; set; } = new();
}