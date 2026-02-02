namespace CampusMediaBack.Services;

using CampusMediaBack.Data;
using CampusMediaBack.Models;
using Microsoft.EntityFrameworkCore;

public class CommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Comment> CreateComment(int postId, string userName, string userSurname, string commentText)
    {
        var comment = new Comment
        {
            PostId = postId,
            UserName = userName,
            UserSurname = userSurname,
            CommentText = commentText,
            Date = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<List<Comment>> GetCommentsByPostId(int postId)
    {
        return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
    }

    public async Task<bool> DeleteComment(int commentId)
    {
        var comment = await _context.Comments.FindAsync(commentId);
        if (comment == null) return false;
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}