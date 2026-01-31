namespace CampusMediaBack.Services;

using CampusMediaBack.Data;
using CampusMediaBack.Models;
using Microsoft.EntityFrameworkCore;
public class UserProfileService
{
    private readonly AppDbContext _context;
    public UserProfileService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<UserProfile> CreateOrUpdateBio(int userId, string bio)
    {
        var profile = await _context.UserProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        if (profile == null)
        {
            profile = new UserProfile { UserId = userId, Bio = bio };
            _context.UserProfiles.Add(profile);
        }
        else
        {
            profile.Bio = bio;
        }
        await _context.SaveChangesAsync();
        return profile;
    }
    public async Task<UserProfile> CreateOrUpdateAbout(int userId, string about)
    {
        var profile = await _context.UserProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        if (profile == null)
        {
            profile = new UserProfile { UserId = userId, About = about };
            _context.UserProfiles.Add(profile);
        }
        else
        {
            profile.About = about;
        }
        await _context.SaveChangesAsync();
        return profile;
    }
    public async Task<UserProfile?> GetProfileByUserId(int userId)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
    }
}