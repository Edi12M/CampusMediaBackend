using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UniversitiesController : ControllerBase
{
    private readonly AppDbContext _context;
    public UniversitiesController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<List<UniversityDto>>> GetUniversities()
    {
        var universities = await _context.Universities.Include(u => u.Departments).ToListAsync();
        return Ok(universities.Select(u => new UniversityDto { Id = u.Id, Name = u.Name, Aliases = u.Aliases, Rating = u.Rating,
            Departments = u.Departments.Select(d => new DepartmentDto { Id = d.Id, Name = d.Name }).ToList() }));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UniversityDto>> GetUniversity(int id)
    {
        var university = await _context.Universities.Include(u => u.Departments).FirstOrDefaultAsync(u => u.Id == id);
        if (university == null) return NotFound();
        return Ok(new UniversityDto { Id = university.Id, Name = university.Name, Aliases = university.Aliases, Rating = university.Rating,
            Departments = university.Departments.Select(d => new DepartmentDto { Id = d.Id, Name = d.Name }).ToList() });
    }
    [HttpGet("top")]
    public async Task<ActionResult<List<UniversityDto>>> GetTopUniversities([FromQuery] int limit = 5)
    {
        var universities = await _context.Universities.OrderByDescending(u => u.Rating).Take(limit).ToListAsync();
        return Ok(universities.Select(u => new UniversityDto { Id = u.Id, Name = u.Name, Aliases = u.Aliases, Rating = u.Rating }));
    }
}
