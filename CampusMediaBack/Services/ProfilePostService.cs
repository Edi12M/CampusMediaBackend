namespace CampusMediaBack.Services;

using CampusMediaBack.Data;
using CampusMediaBack.Models;
using Microsoft.EntityFrameworkCore;

public class ProfilePostService
{
	private readonly AppDbContext _context;

	public ProfilePostService(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Post> CreatePostWithDetails(int userId, string image, string caption, string feeling, string location)
	{
		var post = new Post
		{
			UserId = userId,
			Image = image,
			Caption = caption,
			Date = DateTime.UtcNow.ToString("yyyy-MM-dd")
		};
		_context.Posts.Add(post);
		await _context.SaveChangesAsync();

		var postDetail = new PostDetail
		{
			PostId = post.Id,
			Feeling = feeling,
			Location = location
		};
		_context.PostDetails.Add(postDetail);
		await _context.SaveChangesAsync();

		return post;
	}

	public async Task<PostDetail?> GetPostDetailByPostId(int postId)
	{
		return await _context.PostDetails.FirstOrDefaultAsync(pd => pd.PostId == postId);
	}
}