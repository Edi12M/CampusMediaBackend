namespace CampusMediaBack.Models;
public class Pedagogue
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
