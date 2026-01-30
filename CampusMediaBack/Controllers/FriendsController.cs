using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
using System.Security.Claims;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FriendsController : ControllerBase
{
    private readonly AppDbContext _context;
    public FriendsController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetFriends()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var currentUser = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).FirstOrDefaultAsync(u => u.Id == userId);
        if (currentUser == null) return NotFound();
        var friends = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).Where(u => currentUser.Friends.Contains(u.Id)).ToListAsync();
        return Ok(friends.Select(MapToUserDto));
    }
    [HttpGet("suggestions")]
    public async Task<ActionResult<List<UserDto>>> GetSuggestions()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var currentUser = await _context.Users.FindAsync(userId);
        if (currentUser == null) return NotFound();
        var suggestions = await _context.Users.Include(u => u.Posts).Include(u => u.Stories)
            .Where(u => u.Id != userId && !currentUser.Friends.Contains(u.Id) && (u.University == currentUser.University || currentUser.Suggestions.Contains(u.Id)))
            .Take(10).ToListAsync();
        return Ok(suggestions.Select(MapToUserDto));
    }
    [HttpPost("{friendId}")]
    public async Task<ActionResult<UserDto>> AddFriend(int friendId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var currentUser = await _context.Users.Include(u => u.Posts).Include(u => u.Stories).FirstOrDefaultAsync(u => u.Id == userId);
        var friend = await _context.Users.FindAsync(friendId);
        if (currentUser == null || friend == null) return NotFound();
        if (!currentUser.Friends.Contains(friendId))
        {
            currentUser.Friends.Add(friendId);
            if (!friend.Friends.Contains(userId.Value)) friend.Friends.Add(userId.Value);
            currentUser.Suggestions.Remove(friendId);
            await _context.SaveChangesAsync();
        }
        return Ok(MapToUserDto(currentUser));
    }
    [HttpDelete("{friendId}")]
    public async Task<IActionResult> RemoveFriend(int friendId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var currentUser = await _context.Users.FindAsync(userId);
        var friend = await _context.Users.FindAsync(friendId);
        if (currentUser == null) return NotFound();
        currentUser.Friends.Remove(friendId);
        if (friend != null) friend.Friends.Remove(userId.Value);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("suggestions/{userId}")]
    public async Task<IActionResult> RemoveSuggestion(int userId)
    {
        var currentUserId = GetCurrentUserId();
        if (currentUserId == null) return Unauthorized();
        var currentUser = await _context.Users.FindAsync(currentUserId);
        if (currentUser == null) return NotFound();
        currentUser.Suggestions.Remove(userId);
        await _context.SaveChangesAsync();
        return NoContent();
    }
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
