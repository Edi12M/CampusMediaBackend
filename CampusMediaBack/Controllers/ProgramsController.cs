using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProgramsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ProgramsController(AppDbContext context) { _context = context; }
    [HttpGet("match")]
    public async Task<ActionResult<List<ProgramDto>>> MatchPrograms([FromQuery] string? department = null, [FromQuery] string? type = null)
    {
        var query = _context.Programs.AsQueryable();
        if (!string.IsNullOrEmpty(department) && department.ToLower() != "all")
            query = query.Where(p => p.Department.ToLower().Contains(department.ToLower()));
        if (!string.IsNullOrEmpty(type) && type.ToLower() != "all")
            query = query.Where(p => p.Type.ToLower() == type.ToLower());
        var programs = await query.OrderByDescending(p => p.Rating).ToListAsync();
        return Ok(programs.Select(p => new ProgramDto { Id = p.Id, Name = p.Name, Type = p.Type, Department = p.Department, Rating = p.Rating }));
    }
    [HttpGet("types")]
    public async Task<ActionResult<List<string>>> GetProgramTypes()
    {
        var types = await _context.Programs.Select(p => p.Type).Distinct().ToListAsync();
        return Ok(types);
    }
}
