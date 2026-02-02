namespace CampusMediaBack.DTOs;

public class FriendRequestDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class FriendRequestStatusDto
{
    public string? Status { get; set; }
    public int? RequestId { get; set; }
}

public class UserSuggestionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public int MutualFriendsCount { get; set; }
}

