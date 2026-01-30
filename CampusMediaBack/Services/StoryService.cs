using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;

namespace CampusMediaBack.Services;

public interface IStoryService
{
    Task<List<StoryDto>> GetStories(int currentUserId);
    Task ViewStory(int currentUserId, int storyId);
}

public class StoryService : IStoryService
{
    private readonly AppDbContext _context;
    public StoryService(AppDbContext context) { _context = context; }

    public async Task<List<StoryDto>> GetStories(int currentUserId)
    {
        var currentUser = await _context.Users.FindAsync(currentUserId);
        if (currentUser == null) throw new KeyNotFoundException("User not found");
        var friendIds = currentUser.Friends.Append(currentUserId).ToList();
        var stories = await _context.Stories.Where(s => friendIds.Contains(s.UserId))
            .Select(s => new StoryDto { Id = s.Id, Image = s.Image, Username = s.Username, Viewed = s.ViewedBy.Contains(currentUserId) }).ToListAsync();
        return stories;
    }

    public async Task ViewStory(int currentUserId, int storyId)
    {
        var story = await _context.Stories.FindAsync(storyId);
        if (story == null) throw new KeyNotFoundException("Story not found");
        if (!story.ViewedBy.Contains(currentUserId)) { story.ViewedBy.Add(currentUserId); await _context.SaveChangesAsync(); }
    }
}

