using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampusMediaBack.Services;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FriendsController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;
    public FriendsController(IUserService userService, ICurrentUserService currentUser) { _userService = userService; _currentUser = currentUser; }
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetFriends()
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        try
        {
            var friends = await _userService.GetFriends(userId.Value);
            return Ok(friends);
        }
        catch (KeyNotFoundException) { return NotFound(); }
    }
    [HttpGet("suggestions")]
    public async Task<ActionResult<List<UserDto>>> GetSuggestions()
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        try
        {
            var suggestions = await _userService.GetSuggestions(userId.Value);
            return Ok(suggestions);
        }
        catch (KeyNotFoundException) { return NotFound(); }
    }
    [HttpPost("{friendId}")]
    public async Task<ActionResult<UserDto>> AddFriend(int friendId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var res = await _userService.AddFriend(userId.Value, friendId);
        if (res == null) return NotFound();
        return Ok(res);
    }
    [HttpDelete("{friendId}")]
    public async Task<IActionResult> RemoveFriend(int friendId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        await _userService.RemoveFriend(userId.Value, friendId);
        return NoContent();
    }
    [HttpDelete("suggestions/{userId}")]
    public async Task<IActionResult> RemoveSuggestion(int userId)
    {
        var currentUserId = _currentUser.GetCurrentUserId();
        if (currentUserId == null) return Unauthorized();
        await _userService.RemoveSuggestion(currentUserId.Value, userId);
        return NoContent();
    }
}
