using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampusMediaBack.Services;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class StoriesController : ControllerBase
{
    private readonly IStoryService _storyService;
    private readonly ICurrentUserService _currentUser;
    public StoriesController(IStoryService storyService, ICurrentUserService currentUser) { _storyService = storyService; _currentUser = currentUser; }
    [HttpGet]
    public async Task<ActionResult<List<StoryDto>>> GetStories()
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var stories = await _storyService.GetStories(userId.Value);
        return Ok(stories);
    }
    [HttpPost("{storyId}/view")]
    public async Task<IActionResult> ViewStory(int storyId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        try { await _storyService.ViewStory(userId.Value, storyId); return NoContent(); }
        catch (KeyNotFoundException) { return NotFound(); }
    }
}
