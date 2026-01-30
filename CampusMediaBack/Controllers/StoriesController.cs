using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using System.Security.Claims;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StoriesController : ControllerBase
{
    private readonly AppDbContext _context;
    public StoriesController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<List<StoryDto>>> GetStories()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var currentUser = await _context.Users.FindAsync(userId);
        if (currentUser == null) return NotFound();
        var friendIds = currentUser.Friends.Append(userId.Value).ToList();
        var stories = await _context.Stories.Where(s => friendIds.Contains(s.UserId))
            .Select(s => new StoryDto { Id = s.Id, Image = s.Image, Username = s.Username, Viewed = s.ViewedBy.Contains(userId.Value) }).ToListAsync();
        return Ok(stories);
    }
    [HttpPost("{storyId}/view")]
    public async Task<IActionResult> ViewStory(int storyId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var story = await _context.Stories.FindAsync(storyId);
        if (story == null) return NotFound();
        if (!story.ViewedBy.Contains(userId.Value)) { story.ViewedBy.Add(userId.Value); await _context.SaveChangesAsync(); }
        return NoContent();
    }
    private int? GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return claim != null ? int.Parse(claim) : null;
    }
}
