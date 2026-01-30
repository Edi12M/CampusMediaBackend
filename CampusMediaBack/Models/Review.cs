namespace CampusMediaBack.Models;
public class Review
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string TargetType { get; set; } = string.Empty;
    public int TargetId { get; set; }
    public int Score { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string ReviewerId { get; set; } = string.Empty;
    public string Date { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd");
}
