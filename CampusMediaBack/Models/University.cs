namespace CampusMediaBack.Models;
public class University
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Aliases { get; set; } = new();
    public double Rating { get; set; }
    public List<Department> Departments { get; set; } = new();
}
