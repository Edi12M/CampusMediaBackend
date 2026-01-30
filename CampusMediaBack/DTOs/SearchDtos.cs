namespace CampusMediaBack.DTOs;
public class SearchResult
{
    public List<UserDto> Users { get; set; } = new();
    public List<UniversityDto> Universities { get; set; } = new();
    public List<ProgramDto> Programs { get; set; } = new();
}
public class UniversityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Aliases { get; set; } = new();
    public double Rating { get; set; }
    public List<DepartmentDto> Departments { get; set; } = new();
}
public class DepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProgramDto> Programs { get; set; } = new();
    public List<PedagogueDto> Professors { get; set; } = new();
}
public class ProgramDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public double Rating { get; set; }
}
public class PedagogueDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string University { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public List<string> Courses { get; set; } = new();
    public List<string> ResearchAreas { get; set; } = new();
    public double Rating { get; set; }
    public int YearsOfExperience { get; set; }
}
public class ChartData
{
    public List<string> Labels { get; set; } = new();
    public List<int> Values { get; set; } = new();
}
