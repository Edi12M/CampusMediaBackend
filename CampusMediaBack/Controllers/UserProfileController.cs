using CampusMediaBack.DTOs;
using CampusMediaBack.Services;
using CampusMediaBack.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusMediaBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly UserProfileService _service;
    private readonly AppDbContext _context;

    public UserProfileController(UserProfileService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetProfile(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return NotFound("User not found");

        var profile = await _service.GetProfileByUserId(userId);

        return Ok(new UserProfileResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            University = user.University,
            Department = user.Department,
            ProfileImage = user.ProfileImage,
            Bio = profile?.Bio ?? string.Empty,
            About = profile?.About ?? string.Empty
        });
    }

    [HttpPut("bio/{userId}")]
    public async Task<IActionResult> UpdateBio(int userId, [FromBody] UpdateBioDto dto)
    {
        var profile = await _service.CreateOrUpdateBio(userId, dto.Bio);
        return Ok(new UpdateBioDto { Bio = profile.Bio });
    }

    [HttpPut("about/{userId}")]
    public async Task<IActionResult> UpdateAbout(int userId, [FromBody] UpdateAboutDto dto)
    {
        var profile = await _service.CreateOrUpdateAbout(userId, dto.About);
        return Ok(new UpdateAboutDto { About = profile.About });
    }
}