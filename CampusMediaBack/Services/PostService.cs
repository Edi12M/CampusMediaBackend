using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;

namespace CampusMediaBack.Services;

public interface IPostService
{
    Task<List<FeedPostDto>> GetFeed(int currentUserId);
    Task<List<PostDto>> GetUserPosts(int userId);
    Task<PostDto> CreatePost(int currentUserId, CreatePostRequest request);
    Task DeletePost(int currentUserId, int postId);
    Task<PostDto?> LikePost(int currentUserId, int postId);
    Task<PostDto?> UnlikePost(int currentUserId, int postId);
}

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    private readonly CommentService _commentService;
    public PostService(AppDbContext context, CommentService commentService) 
    { 
        _context = context; 
        _commentService = commentService;
    }

    public async Task<List<FeedPostDto>> GetFeed(int currentUserId)
    {
        var currentUser = await _context.Users.FindAsync(currentUserId);
        if (currentUser == null) throw new KeyNotFoundException("User not found");
        var friendIds = currentUser.Friends.Append(currentUserId).ToList();
        var posts = await _context.Posts.Where(p => friendIds.Contains(p.UserId))
            .OrderByDescending(p => p.Date).ToListAsync();
        var feedPosts = new List<FeedPostDto>();
        foreach (var post in posts)
        {
            var poster = await _context.Users.FindAsync(post.UserId);
            if (poster != null)
            {
                // Get post details (feeling and location)
                var postDetail = await _context.PostDetails.FirstOrDefaultAsync(pd => pd.PostId == post.Id);
                
                // Get comments for this post
                var comments = await _commentService.GetCommentsByPostId(post.Id);
                var commentDtos = comments.Select(c => new CommentResponseDto
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    UserSurname = c.UserSurname,
                    CommentText = c.CommentText,
                    Date = c.Date
                }).ToList();

                feedPosts.Add(new FeedPostDto 
                { 
                    Id = post.Id, 
                    Image = post.Image, 
                    Caption = post.Caption, 
                    Date = post.Date, 
                    Likes = post.Likes, 
                    PosterName = poster.Name, 
                    PosterImage = poster.ProfileImage, 
                    PosterId = poster.Id,
                    Feeling = postDetail?.Feeling,
                    Location = postDetail?.Location,
                    Comments = commentDtos
                });
            }
        }
        return feedPosts;
    }

    public async Task<List<PostDto>> GetUserPosts(int userId)
    {
        var posts = await _context.Posts.Where(p => p.UserId == userId).OrderByDescending(p => p.Date)
            .Select(p => new PostDto { Id = p.Id, Image = p.Image, Caption = p.Caption, Date = p.Date, Likes = p.Likes }).ToListAsync();
        return posts;
    }

    public async Task<PostDto> CreatePost(int currentUserId, CreatePostRequest request)
    {
        var post = new Post { UserId = currentUserId, Image = request.Image, Caption = request.Caption, Date = request.Date };
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return new PostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes };
    }

    public async Task DeletePost(int currentUserId, int postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null) throw new KeyNotFoundException("Post not found");
        if (post.UserId != currentUserId) throw new UnauthorizedAccessException();
        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
    }

    public async Task<PostDto?> LikePost(int currentUserId, int postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null) return null;
        if (!post.Likes.Contains(currentUserId)) { post.Likes.Add(currentUserId); await _context.SaveChangesAsync(); }
        return new PostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes };
    }

    public async Task<PostDto?> UnlikePost(int currentUserId, int postId)
    {
        var post = await _context.Posts.FindAsync(postId);
        if (post == null) return null;
        post.Likes.Remove(currentUserId);
        await _context.SaveChangesAsync();
        return new PostDto { Id = post.Id, Image = post.Image, Caption = post.Caption, Date = post.Date, Likes = post.Likes };
    }
}

