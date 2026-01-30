using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
using CampusMediaBack.Services;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ICurrentUserService _currentUser;
    public AuthController(IAuthService authService, ICurrentUserService currentUser)
    {
        _authService = authService;
        _currentUser = currentUser;
    }
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request)
    {
        var res = await _authService.Login(request);
        if (res == null) return Unauthorized(new { message = "Invalid email or password" });
        return Ok(res);
    }
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
    {
        var res = await _authService.Register(request);
        if (res == null) return BadRequest(new { message = "Email already exists" });
        return Ok(res);
    }
    [HttpPost("logout")]
    [Authorize]
    public IActionResult Logout() => NoContent();
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var user = await _authService.GetCurrentUser(userId.Value);
        if (user == null) return NotFound();
        return Ok(user);
    }
    [HttpGet("status")]
    [Authorize]
    public IActionResult GetStatus() => Ok(new { authenticated = true });
}
