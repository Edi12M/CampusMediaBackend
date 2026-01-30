namespace CampusMediaBack.DTOs;
public class CreateStudentRequest
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
}
public class UpdateStudentRequest
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? University { get; set; }
    public string? Department { get; set; }
    public string? ProfileImage { get; set; }
}
