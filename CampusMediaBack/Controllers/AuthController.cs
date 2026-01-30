using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
using CampusMediaBack.Services;
using System.Security.Claims;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    public AuthController(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
    {
        var user = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized(new { message = "Invalid email or password" });
        return Ok(new AuthResponse { User = MapToUserDto(user), Token = _tokenService.GenerateToken(user) });
    }
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            return BadRequest(new { message = "Email already exists" });
        var user = new User
        {
            Name = request.Name, Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            University = request.University, Department = request.Department,
            ProfileImage = request.ProfileImage, Role = "student"
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(new AuthResponse { User = MapToUserDto(user), Token = _tokenService.GenerateToken(user) });
    }
    [HttpPost("logout")]
    [Authorize]
    public IActionResult Logout() => NoContent();
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var user = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return NotFound();
        return Ok(MapToUserDto(user));
    }
    [HttpGet("status")]
    [Authorize]
    public IActionResult GetStatus() => Ok(new { authenticated = true });
    private int? GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return claim != null ? int.Parse(claim) : null;
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
