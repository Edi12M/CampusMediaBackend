using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;

namespace CampusMediaBack.Services;

public interface IAuthService
{
    Task<AuthResponse?> Login(LoginRequest request);
    Task<AuthResponse?> Register(RegisterRequest request);
    Task<UserDto?> GetCurrentUser(int id);
}

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    public AuthService(AppDbContext context, ITokenService tokenService)
    {
        _context = context; _tokenService = tokenService;
    }

    private static UserDto MapToUserDto(User user) => new()
    {
        Id = user.Id, Name = user.Name, Email = user.Email, University = user.University,
        Department = user.Department, ProfileImage = user.ProfileImage, Role = user.Role,
        Friends = user.Friends, Suggestions = user.Suggestions,
        Posts = user.Posts.Select(p => new PostDto { Id = p.Id, Image = p.Image, Caption = p.Caption, Date = p.Date, Likes = p.Likes }).ToList(),
        Stories = user.Stories.Select(s => new StoryDto { Id = s.Id, Image = s.Image, Username = s.Username, Viewed = false }).ToList()
    };

    public async Task<AuthResponse?> Login(LoginRequest request)
    {
        var user = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Email == request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;
        return new AuthResponse { User = MapToUserDto(user), Token = _tokenService.GenerateToken(user) };
    }

    public async Task<AuthResponse?> Register(RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email)) return null;
        var user = new User
        {
            Name = request.Name, Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            University = request.University, Department = request.Department,
            ProfileImage = request.ProfileImage, Role = "student"
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return new AuthResponse { User = MapToUserDto(user), Token = _tokenService.GenerateToken(user) };
    }

    public async Task<UserDto?> GetCurrentUser(int id)
    {
        var user = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return null;
        return MapToUserDto(user);
    }
}

