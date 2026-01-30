using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly AppDbContext _context;
    public SearchController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<SearchResult>> Search([FromQuery] string q = "")
    {
        if (string.IsNullOrWhiteSpace(q)) return Ok(new SearchResult());
        var query = q.ToLower();
        var users = await _context.Users.Where(u => u.Name.ToLower().Contains(query) || u.Email.ToLower().Contains(query) || u.University.ToLower().Contains(query)).Take(10).ToListAsync();
        var universities = await _context.Universities.Where(u => u.Name.ToLower().Contains(query) || u.Aliases.Any(a => a.ToLower().Contains(query))).Take(10).ToListAsync();
        var programs = await _context.Programs.Where(p => p.Name.ToLower().Contains(query) || p.Type.ToLower().Contains(query) || p.Department.ToLower().Contains(query)).Take(10).ToListAsync();
        return Ok(new SearchResult
        {
            Users = users.Select(u => new UserDto { Id = u.Id, Name = u.Name, Email = u.Email, University = u.University, Department = u.Department, ProfileImage = u.ProfileImage, Role = u.Role }).ToList(),
            Universities = universities.Select(u => new UniversityDto { Id = u.Id, Name = u.Name, Aliases = u.Aliases, Rating = u.Rating }).ToList(),
            Programs = programs.Select(p => new ProgramDto { Id = p.Id, Name = p.Name, Type = p.Type, Department = p.Department, Rating = p.Rating }).ToList()
        });
    }
}
