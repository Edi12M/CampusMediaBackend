using CampusMediaBack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CampusMediaBack.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class FriendRequestController : ControllerBase
{
    private readonly FriendRequestService _friendRequestService;
    private readonly ICurrentUserService _currentUserService;

    public FriendRequestController(FriendRequestService friendRequestService, ICurrentUserService currentUserService)
    {
        _friendRequestService = friendRequestService;
        _currentUserService = currentUserService;
    }

    [HttpPost("{receiverId}")]
    public async Task<IActionResult> SendRequest(int receiverId)
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        try
        {
            var request = await _friendRequestService.SendRequest(userId.Value, receiverId);
            return Ok(new { message = "Friend request sent", requestId = request.Id });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingRequests()
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        var requests = await _friendRequestService.GetPendingRequests(userId.Value);
        return Ok(requests);
    }

    [HttpGet("sent")]
    public async Task<IActionResult> GetSentRequests()
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        var requests = await _friendRequestService.GetSentRequests(userId.Value);
        return Ok(requests);
    }

    [HttpGet("status/{otherUserId}")]
    public async Task<IActionResult> GetRequestStatus(int otherUserId)
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        var status = await _friendRequestService.GetRequestStatus(userId.Value, otherUserId);
        return Ok(status);
    }

    [HttpPost("{requestId}/accept")]
    public async Task<IActionResult> AcceptRequest(int requestId)
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        try
        {
            await _friendRequestService.AcceptRequest(requestId, userId.Value);
            return Ok(new { message = "Friend request accepted" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
    }

    [HttpPost("{requestId}/reject")]
    public async Task<IActionResult> RejectRequest(int requestId)
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        try
        {
            await _friendRequestService.RejectRequest(requestId, userId.Value);
            return Ok(new { message = "Friend request rejected" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
    }

    [HttpDelete("{requestId}")]
    public async Task<IActionResult> CancelRequest(int requestId)
    {
        var userId = _currentUserService.GetCurrentUserId();
        if (userId == null)
            return Unauthorized();
        try
        {
            await _friendRequestService.CancelRequest(requestId, userId.Value);
            return Ok(new { message = "Friend request cancelled" });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid();
        }
    }
}
