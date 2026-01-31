namespace CampusMediaBack.DTOs;

public class CommentResponseDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserSurname { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
}