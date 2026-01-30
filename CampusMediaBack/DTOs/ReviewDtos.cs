namespace CampusMediaBack.DTOs;
public class CreateReviewRequest
{
    public string TargetType { get; set; } = string.Empty;
    public int TargetId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; } = string.Empty;
}
public class UpdateReviewRequest
{
    public int Score { get; set; }
    public string Comment { get; set; } = string.Empty;
}
public class ReviewDto
{
    public string Id { get; set; } = string.Empty;
    public string TargetType { get; set; } = string.Empty;
    public int TargetId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ReviewerId { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
}
