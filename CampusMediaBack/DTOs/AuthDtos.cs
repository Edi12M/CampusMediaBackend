namespace CampusMediaBack.DTOs;
public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
public class RegisterRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
}
public class AuthResponse
{
    public UserDto User { get; set; } = null!;
    public string Token { get; set; } = string.Empty;
}
public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public List<int> Friends { get; set; } = new();
    public List<int> Suggestions { get; set; } = new();
    public List<PostDto> Posts { get; set; } = new();
    public List<StoryDto> Stories { get; set; } = new();
}
