using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;

namespace CampusMediaBack.Services;

public interface IUserService
{
    Task<UserDto?> GetById(int id);
    Task<List<UserDto>> GetAllStudents();
    Task<UserDto> CreateStudent(CreateStudentRequest request);
    Task<UserDto?> UpdateStudent(int id, UpdateStudentRequest request);
    Task<List<UserDto>> GetFriends(int currentUserId);
    Task<List<UserDto>> GetSuggestions(int currentUserId);
    Task<UserDto?> AddFriend(int currentUserId, int friendId);
    Task RemoveFriend(int currentUserId, int friendId);
    Task RemoveSuggestion(int currentUserId, int userId);
    Task DeleteUser(int id);
}

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context) { _context = context; }

    private static UserDto MapToUserDto(User user) => new()
    {
        Id = user.Id, Name = user.Name, Email = user.Email, University = user.University,
        Department = user.Department, ProfileImage = user.ProfileImage, Role = user.Role,
        Friends = user.Friends, Suggestions = user.Suggestions,
        Posts = user.Posts.Select(p => new PostDto { Id = p.Id, Image = p.Image, Caption = p.Caption, Date = p.Date, Likes = p.Likes }).ToList(),
        Stories = user.Stories.Select(s => new StoryDto { Id = s.Id, Image = s.Image, Username = s.Username, Viewed = false }).ToList()
    };

    public async Task<UserDto?> GetById(int id)
    {
        var student = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (student == null) return null;
        return MapToUserDto(student);
    }

    public async Task<List<UserDto>> GetAllStudents()
    {
        var students = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .Where(u => u.Role == "student").ToListAsync();
        return students.Select(MapToUserDto).ToList();
    }

    public async Task<UserDto> CreateStudent(CreateStudentRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            throw new InvalidOperationException("Email already exists");
        var student = new User
        {
            Name = request.Name, Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            University = request.University, Department = request.Department,
            ProfileImage = request.ProfileImage, Role = "student"
        };
        _context.Users.Add(student);
        await _context.SaveChangesAsync();
        return MapToUserDto(student);
    }

    public async Task<UserDto?> UpdateStudent(int id, UpdateStudentRequest request)
    {
        var student = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .FirstOrDefaultAsync(u => u.Id == id);
        if (student == null) return null;
        if (request.Name != null) student.Name = request.Name;
        if (request.Email != null) student.Email = request.Email;
        if (request.University != null) student.University = request.University;
        if (request.Department != null) student.Department = request.Department;
        if (request.ProfileImage != null) student.ProfileImage = request.ProfileImage;
        await _context.SaveChangesAsync();
        return MapToUserDto(student);
    }

    public async Task<List<UserDto>> GetFriends(int currentUserId)
    {
        var currentUser = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).FirstOrDefaultAsync(u => u.Id == currentUserId);
        if (currentUser == null) throw new KeyNotFoundException("User not found");
        var friends = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).Where(u => currentUser.Friends.Contains(u.Id)).ToListAsync();
        return friends.Select(MapToUserDto).ToList();
    }

    public async Task<List<UserDto>> GetSuggestions(int currentUserId)
    {
        var currentUser = await _context.Users.FindAsync(currentUserId);
        if (currentUser == null) throw new KeyNotFoundException("User not found");
        var suggestions = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .Where(u => u.Id != currentUserId && !currentUser.Friends.Contains(u.Id) && (u.University == currentUser.University || currentUser.Suggestions.Contains(u.Id)))
            .Take(10).ToListAsync();
        return suggestions.Select(MapToUserDto).ToList();
    }

    public async Task<UserDto?> AddFriend(int currentUserId, int friendId)
    {
        var currentUser = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).FirstOrDefaultAsync(u => u.Id == currentUserId);
        var friend = await _context.Users.FindAsync(friendId);
        if (currentUser == null || friend == null) return null;
        if (!currentUser.Friends.Contains(friendId))
        {
            currentUser.Friends.Add(friendId);
            if (!friend.Friends.Contains(currentUserId)) friend.Friends.Add(currentUserId);
            currentUser.Suggestions.Remove(friendId);
            await _context.SaveChangesAsync();
        }
        return MapToUserDto(currentUser);
    }

    public async Task RemoveFriend(int currentUserId, int friendId)
    {
        var currentUser = await _context.Users.FindAsync(currentUserId);
        var friend = await _context.Users.FindAsync(friendId);
        if (currentUser == null) throw new KeyNotFoundException("User not found");
        currentUser.Friends.Remove(friendId);
        if (friend != null) friend.Friends.Remove(currentUserId);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveSuggestion(int currentUserId, int userId)
    {
        var currentUser = await _context.Users.FindAsync(currentUserId);
        if (currentUser == null) throw new KeyNotFoundException("User not found");
        currentUser.Suggestions.Remove(userId);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var student = await _context.Users.FindAsync(id);
        if (student == null) throw new KeyNotFoundException("User not found");
        _context.Users.Remove(student);
        await _context.SaveChangesAsync();
    }
}
