namespace CampusMediaBack.DTOs;
public class MatchRequest
{
    public string University { get; set; } = string.Empty;
    public List<string> Courses { get; set; } = new();
}
