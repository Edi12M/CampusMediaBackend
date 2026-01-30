namespace CampusMediaBack.Models;
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Program> Programs { get; set; } = new();
    public List<Pedagogue> Professors { get; set; } = new();
}
