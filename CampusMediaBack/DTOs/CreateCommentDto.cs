namespace CampusMediaBack.DTOs;

public class CreateCommentDto
{
    public int PostId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserSurname { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
}