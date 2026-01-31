namespace CampusMediaBack.DTOs;

public class UserProfileResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
}