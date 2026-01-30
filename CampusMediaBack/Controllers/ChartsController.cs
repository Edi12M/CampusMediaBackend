using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ChartsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ChartsController(AppDbContext context) { _context = context; }
    [HttpGet("universities-by-department")]
    public async Task<ActionResult<ChartData>> GetUniversitiesByDepartment([FromQuery] string type = "All")
    {
        var departments = await _context.Departments.Select(d => d.Name).Distinct().ToListAsync();
        var labels = new List<string>();
        var values = new List<int>();
        foreach (var department in departments)
        {
            int count;
            if (type.ToLower() != "all")
                count = await _context.Programs.Where(p => p.Department == department && p.Type.ToLower() == type.ToLower()).CountAsync();
            else
                count = await _context.Programs.Where(p => p.Department == department).CountAsync();
            if (count > 0 || type.ToLower() == "all") { labels.Add(department); values.Add(count); }
        }
        return Ok(new ChartData { Labels = labels, Values = values });
    }
}
