using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PedagoguesController : ControllerBase
{
    private readonly AppDbContext _context;
    public PedagoguesController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<List<PedagogueDto>>> GetPedagogues()
    {
        var pedagogues = await _context.Pedagogues.ToListAsync();
        return Ok(pedagogues.Select(MapToPedagogueDto));
    }
    [HttpGet("top")]
    public async Task<ActionResult<List<PedagogueDto>>> GetTopPedagogues([FromQuery] int limit = 5)
    {
        var pedagogues = await _context.Pedagogues.OrderByDescending(p => p.Rating).Take(limit).ToListAsync();
        return Ok(pedagogues.Select(MapToPedagogueDto));
    }
    [HttpGet("search")]
    public async Task<ActionResult<List<PedagogueDto>>> SearchPedagogues([FromQuery] string q = "")
    {
        var query = q.ToLower();
        var pedagogues = await _context.Pedagogues
            .Where(p => p.Name.ToLower().Contains(query) || p.Surname.ToLower().Contains(query) || p.University.ToLower().Contains(query) || p.Department.ToLower().Contains(query))
            .ToListAsync();
        return Ok(pedagogues.Select(MapToPedagogueDto));
    }
    [HttpPost("match")]
    public async Task<ActionResult<List<PedagogueDto>>> MatchPedagogues([FromBody] MatchRequest request)
    {
        var pedagogues = await _context.Pedagogues
            .Where(p => p.University.ToLower().Contains(request.University.ToLower()) || p.Courses.Any(c => request.Courses.Any(rc => c.ToLower().Contains(rc.ToLower()))))
            .OrderByDescending(p => p.Rating).ToListAsync();
        return Ok(pedagogues.Select(MapToPedagogueDto));
    }
    private static PedagogueDto MapToPedagogueDto(Models.Pedagogue p) => new()
    {
        Id = p.Id, Name = p.Name, Surname = p.Surname, University = p.University, Department = p.Department,
        Courses = p.Courses, ResearchAreas = p.ResearchAreas, Rating = p.Rating, YearsOfExperience = p.YearsOfExperience
    };
}
