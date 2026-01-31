namespace CampusMediaBack.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserSurname { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
}