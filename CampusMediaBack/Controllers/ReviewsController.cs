using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampusMediaBack.Services;
using CampusMediaBack.DTOs;
namespace CampusMediaBack.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly ICurrentUserService _currentUser;
    public ReviewsController(IReviewService reviewService, ICurrentUserService currentUser) { _reviewService = reviewService; _currentUser = currentUser; }
    [HttpGet]
    public async Task<ActionResult<List<ReviewDto>>> GetReviews()
    {
        var reviews = await _reviewService.GetAll();
        return Ok(reviews);
    }
    [HttpGet("university/{universityId}")]
    public async Task<ActionResult<List<ReviewDto>>> GetUniversityReviews(int universityId)
    {
        var reviews = await _reviewService.GetByTarget("uni", universityId);
        return Ok(reviews);
    }
    [HttpGet("pedagogue/{pedagogueId}")]
    public async Task<ActionResult<List<ReviewDto>>> GetPedagogueReviews(int pedagogueId)
    {
        var reviews = await _reviewService.GetByTarget("prof", pedagogueId);
        return Ok(reviews);
    }
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<List<ReviewDto>>> GetMyReviews()
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var reviews = await _reviewService.GetByReviewer(userId.Value);
        return Ok(reviews);
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ReviewDto>> CreateReview([FromBody] CreateReviewRequest request)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var review = await _reviewService.CreateReview(userId.Value, request);
        return Ok(review);
    }
    [HttpPut("{reviewId}")]
    [Authorize]
    public async Task<ActionResult<ReviewDto>> UpdateReview(string reviewId, [FromBody] UpdateReviewRequest request)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        try
        {
            var review = await _reviewService.UpdateReview(userId.Value, reviewId, request);
            if (review == null) return NotFound();
            return Ok(review);
        }
        catch (UnauthorizedAccessException) { return Forbid(); }
    }
    [HttpDelete("{reviewId}")]
    [Authorize]
    public async Task<IActionResult> DeleteReview(string reviewId)
    {
        var userId = _currentUser.GetCurrentUserId();
        if (userId == null) return Unauthorized();
        try
        {
            await _reviewService.DeleteReview(userId.Value, reviewId);
            return NoContent();
        }
        catch (UnauthorizedAccessException) { return Forbid(); }
        catch (KeyNotFoundException) { return NotFound(); }
    }
}
