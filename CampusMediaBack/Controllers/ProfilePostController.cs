using CampusMediaBack.DTOs;
using CampusMediaBack.Services;
using CampusMediaBack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusMediaBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilePostController : ControllerBase
{
    private readonly ProfilePostService _postService;
    private readonly CommentService _commentService;
    private readonly AppDbContext _context;

    public ProfilePostController(ProfilePostService postService, CommentService commentService, AppDbContext context)
    {
        _postService = postService;
        _commentService = commentService;
        _context = context;
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> CreatePost(int userId, [FromBody] CreatePostFromProfileDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return NotFound("User not found");

        var post = await _postService.CreatePostWithDetails(userId, dto.Image, dto.Caption, dto.Feeling, dto.Location);
        var detail = await _postService.GetPostDetailByPostId(post.Id);

        return Ok(new
        {
            PostId = post.Id,
            UserId = post.UserId,
            Image = post.Image,
            Caption = post.Caption,
            Date = post.Date,
            Feeling = detail?.Feeling,
            Location = detail?.Location
        });
    }

    [HttpPost("comment")]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto dto)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == dto.PostId);
        if (post == null) return NotFound("Post not found");

        var comment = await _commentService.CreateComment(dto.PostId, dto.UserName, dto.UserSurname, dto.CommentText);
        return Ok(comment);
    }

    [HttpGet("posts/{userId}")]
    public async Task<IActionResult> GetUserPosts(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return NotFound("User not found");

        var posts = await _context.Posts.Where(p => p.UserId == userId).ToListAsync();

        var response = new List<PostResponseDto>();
        foreach (var post in posts)
        {
            var detail = await _postService.GetPostDetailByPostId(post.Id);
            var comments = await _commentService.GetCommentsByPostId(post.Id);

            response.Add(new PostResponseDto
            {
                PostId = post.Id,
                UserId = post.UserId,
                Image = post.Image,
                Caption = post.Caption,
                Date = post.Date,
                Feeling = detail?.Feeling,
                Location = detail?.Location,
                Comments = comments.Select(c => new CommentResponseDto
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    UserSurname = c.UserSurname,
                    CommentText = c.CommentText,
                    Date = c.Date
                }).ToList()
            });
        }

        return Ok(response);
    }
}
