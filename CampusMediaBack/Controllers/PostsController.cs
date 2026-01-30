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
public class PostsController : ControllerBase
{
    private readonly AppDbContext _context;
    public PostsController(AppDbContext context) { _context = context; }
    [HttpGet("feed")]
    public async Task<ActionResult<List<FeedPostDto>>> GetFeed()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var currentUser = await _context.Users.FindAsync(userId);
        if (currentUser == null) return NotFound();
        var friendIds = currentUser.Friends.Append(userId.Value).ToList();
        var posts = await _context.Posts.Where(p => friendIds.Contains(p.UserId))
            .OrderByDescending(p => p.Date).ToListAsync();
        var feedPosts = new List<FeedPostDto>();
        foreach (var post in posts)
        {
            var poster = await _context.Users.FindAsync(post.UserId);
            if (poster != null)
                feedPosts.Add(new FeedPostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes, PosterName = poster.Name, PosterImage = poster.ProfileImage, PosterId = poster.Id });
        }
        return Ok(feedPosts);
    }
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<PostDto>>> GetUserPosts(int userId)
    {
        var posts = await _context.Posts.Where(p => p.UserId == userId).OrderByDescending(p => p.Date)
            .Select(p => new PostDto { Id = p.Id, Image = p.Image, Caption = p.Caption, Date = p.Date, Likes = p.Likes }).ToListAsync();
        return Ok(posts);
    }
    [HttpPost]
    public async Task<ActionResult<PostDto>> CreatePost([FromBody] CreatePostRequest request)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var post = new Post { UserId = userId.Value, Image = request.Image, Caption = request.Caption, Date = request.Date };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return Ok(new PostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes });
    }
    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePost(int postId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var post = await _context.Posts.FindAsync(postId);
        if (post == null) return NotFound();
        if (post.UserId != userId) return Forbid();
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpPost("{postId}/like")]
    public async Task<ActionResult<PostDto>> LikePost(int postId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var post = await _context.Posts.FindAsync(postId);
        if (post == null) return NotFound();
        if (!post.Likes.Contains(userId.Value)) { post.Likes.Add(userId.Value); await _context.SaveChangesAsync(); }
        return Ok(new PostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes });
    }
    [HttpPost("{postId}/unlike")]
    public async Task<ActionResult<PostDto>> UnlikePost(int postId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var post = await _context.Posts.FindAsync(postId);
        if (post == null) return NotFound();
        post.Likes.Remove(userId.Value);
        await _context.SaveChangesAsync();
        return Ok(new PostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes });
    }
    private int? GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return claim != null ? int.Parse(claim) : null;
    }
}
