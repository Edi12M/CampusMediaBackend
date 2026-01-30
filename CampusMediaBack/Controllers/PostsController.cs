using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampusMediaBack.Services;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly ICurrentUserService _currentUser;
    public PostsController(IPostService postService, ICurrentUserService currentUser) { _postService = postService; _currentUser = currentUser; }
    [HttpGet("feed")]
    public async Task<ActionResult<List<FeedPostDto>>> GetFeed()
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var feed = await _postService.GetFeed(userId.Value);
        return Ok(feed);
    }
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<PostDto>>> GetUserPosts(int userId)
    {
        var posts = await _postService.GetUserPosts(userId);
        return Ok(posts);
    }
    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostRequest request)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var post = await _postService.CreatePost(userId.Value, request);
        return Ok(post);
    }
    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePost(int postId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        try
        {
            await _postService.DeletePost(userId.Value, postId);
            return NoContent();
        }
        catch (UnauthorizedAccessException) { return Forbid(); }
        catch (KeyNotFoundException) { return NotFound(); }
    }
    [HttpPost("{postId}/like")]
    public async Task<ActionResult<PostDto>> LikePost(int postId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var res = await _postService.LikePost(userId.Value, postId);
        if (res == null) return NotFound();
        return Ok(res);
    }
    [HttpPost("{postId}/unlike")]
    public async Task<ActionResult<PostDto>> UnlikePost(int postId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var res = await _postService.UnlikePost(userId.Value, postId);
        if (res == null) return NotFound();
        return Ok(res);
    }
}
