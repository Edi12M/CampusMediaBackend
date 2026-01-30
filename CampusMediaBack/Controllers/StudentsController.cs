using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public StudentsController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAllStudents()
    {
        var students = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .Where(u => u.Role == "student").ToListAsync();
        return Ok(students.Select(MapToUserDto));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetStudent(int id)
    {
        var student = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (student == null) return NotFound();
        return Ok(MapToUserDto(student));
    }
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateStudent([FromBody] CreateStudentRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            return BadRequest(new { message = "Email already exists" });
        var student = new User
        {
            Name = request.Name, Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            University = request.University, Department = request.Department,
            ProfileImage = request.ProfileImage, Role = "student"
        };
        _context.Users.Add(student);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, MapToUserDto(student));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateStudent(int id, [FromBody] UpdateStudentRequest request)
    {
        var student = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (student == null) return NotFound();
        if (request.Name != null) student.Name = request.Name;
        if (request.Email != null) student.Email = request.Email;
        if (request.University != null) student.University = request.University;
        if (request.Department != null) student.Department = request.Department;
        if (request.ProfileImage != null) student.ProfileImage = request.ProfileImage;
        await _context.SaveChangesAsync();
        return Ok(MapToUserDto(student));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _context.Users.FindAsync(id);
        if (student == null) return NotFound();
        _context.Users.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private static UserDto MapToUserDto(User user) => new()
    {
        Id = user.Id, Name = user.Name, Email = user.Email, University = user.University,
        Department = user.Department, ProfileImage = user.ProfileImage, Role = user.Role,
        Friends = user.Friends, Suggestions = user.Suggestions,
        Posts = user.Posts.Select(p => new PostDto { Id = p.Id, Image = p.Image, Caption = p.Caption, Date = p.Date, Likes = p.Likes }).ToList(),
        Stories = user.Stories.Select(s => new StoryDto { Id = s.Id, Image = s.Image, Username = s.Username, Viewed = false }).ToList()
    };
}
