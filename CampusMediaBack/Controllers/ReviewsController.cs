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
public class ReviewsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ReviewsController(AppDbContext context) { _context = context; }
    [HttpGet]
    public async Task<ActionResult<List<ReviewDto>>> GetReviews()
    {
        var reviews = await _context.Reviews.ToListAsync();
        return Ok(reviews.Select(MapToReviewDto));
    }
    [HttpGet("university/{universityId}")]
    public async Task<ActionResult<List<ReviewDto>>> GetUniversityReviews(int universityId)
    {
        var reviews = await _context.Reviews.Where(r => r.TargetType == "uni" && r.TargetId == universityId).ToListAsync();
        return Ok(reviews.Select(MapToReviewDto));
    }
    [HttpGet("pedagogue/{pedagogueId}")]
    public async Task<ActionResult<List<ReviewDto>>> GetPedagogueReviews(int pedagogueId)
    {
        var reviews = await _context.Reviews.Where(r => r.TargetType == "prof" && r.TargetId == pedagogueId).ToListAsync();
        return Ok(reviews.Select(MapToReviewDto));
    }
    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<List<ReviewDto>>> GetMyReviews()
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var reviews = await _context.Reviews.Where(r => r.ReviewerId == userId.ToString()).ToListAsync();
        return Ok(reviews.Select(MapToReviewDto));
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ReviewDto>> CreateReview([FromBody] CreateReviewRequest request)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var review = new Review { Id = Guid.NewGuid().ToString(), TargetType = request.TargetType, TargetId = request.TargetId,
            Score = request.Score, Comment = request.Comment, ReviewerId = userId.ToString()!, Date = DateTime.UtcNow.ToString("yyyy-MM-dd") };
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        await UpdateTargetRating(request.TargetType, request.TargetId);
        return Ok(MapToReviewDto(review));
    }
    [HttpPut("{reviewId}")]
    [Authorize]
    public async Task<ActionResult<ReviewDto>> UpdateReview(string reviewId, [FromBody] UpdateReviewRequest request)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null) return NotFound();
        if (review.ReviewerId != userId.ToString()) return Forbid();
        review.Score = request.Score;
        review.Comment = request.Comment;
        await _context.SaveChangesAsync();
        await UpdateTargetRating(review.TargetType, review.TargetId);
        return Ok(MapToReviewDto(review));
    }
    [HttpDelete("{reviewId}")]
    [Authorize]
    public async Task<IActionResult> DeleteReview(string reviewId)
    {
        var userId = GetCurrentUserId();
        if (userId == null) return Unauthorized();
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null) return NotFound();
        if (review.ReviewerId != userId.ToString()) return Forbid();
        var targetType = review.TargetType;
        var targetId = review.TargetId;
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        await UpdateTargetRating(targetType, targetId);
        return NoContent();
    }
    private async Task UpdateTargetRating(string targetType, int targetId)
    {
        var reviews = await _context.Reviews.Where(r => r.TargetType == targetType && r.TargetId == targetId).ToListAsync();
        if (reviews.Count == 0) return;
        var averageRating = reviews.Average(r => r.Score);
        if (targetType == "uni") { var uni = await _context.Universities.FindAsync(targetId); if (uni != null) { uni.Rating = Math.Round(averageRating, 2); await _context.SaveChangesAsync(); } }
        else if (targetType == "prof") { var ped = await _context.Pedagogues.FindAsync(targetId); if (ped != null) { ped.Rating = Math.Round(averageRating, 2); await _context.SaveChangesAsync(); } }
    }
    private int? GetCurrentUserId() { var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; return claim != null ? int.Parse(claim) : null; }
    private static ReviewDto MapToReviewDto(Review r) => new() { Id = r.Id, TargetType = r.TargetType, TargetId = r.TargetId, Score = r.Score, Comment = r.Comment, ReviewerId = r.ReviewerId, Date = r.Date };
}
