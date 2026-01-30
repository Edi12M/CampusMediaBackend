using Microsoft.EntityFrameworkCore;
using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;

namespace CampusMediaBack.Services;

public interface IReviewService
{
    Task<List<ReviewDto>> GetAll();
    Task<List<ReviewDto>> GetByTarget(string targetType, int targetId);
    Task<List<ReviewDto>> GetByReviewer(int userId);
    Task<ReviewDto> CreateReview(int userId, CreateReviewRequest request);
    Task<ReviewDto?> UpdateReview(int userId, string reviewId, UpdateReviewRequest request);
    Task DeleteReview(int userId, string reviewId);
}

public class ReviewService : IReviewService
{
    private readonly AppDbContext _context;
    public ReviewService(AppDbContext context) { _context = context; }

    private static ReviewDto MapToReviewDto(Review r) => new() { Id = r.Id, TargetType = r.TargetType, TargetId = r.TargetId, Score = r.Score, Comment = r.Comment, ReviewerId = r.ReviewerId, Date = r.Date };

    public async Task<List<ReviewDto>> GetAll()
    {
        var reviews = await _context.Reviews.ToListAsync();
        return reviews.Select(MapToReviewDto).ToList();
    }

    public async Task<List<ReviewDto>> GetByTarget(string targetType, int targetId)
    {
        var reviews = await _context.Reviews.Where(r => r.TargetType == targetType && r.TargetId == targetId).ToListAsync();
        return reviews.Select(MapToReviewDto).ToList();
    }

    public async Task<List<ReviewDto>> GetByReviewer(int userId)
    {
        var reviews = await _context.Reviews.Where(r => r.ReviewerId == userId.ToString()).ToListAsync();
        return reviews.Select(MapToReviewDto).ToList();
    }

    public async Task<ReviewDto> CreateReview(int userId, CreateReviewRequest request)
    {
        var review = new Review { Id = Guid.NewGuid().ToString(), TargetType = request.TargetType, TargetId = request.TargetId,
            Score = request.Score, Comment = request.Comment, ReviewerId = userId.ToString(), Date = DateTime.UtcNow.ToString("yyyy-MM-dd") };
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        await UpdateTargetRating(request.TargetType, request.TargetId);
        return MapToReviewDto(review);
    }

    public async Task<ReviewDto?> UpdateReview(int userId, string reviewId, UpdateReviewRequest request)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null) return null;
        if (review.ReviewerId != userId.ToString()) throw new UnauthorizedAccessException();
        review.Score = request.Score;
        review.Comment = request.Comment;
        await _context.SaveChangesAsync();
        await UpdateTargetRating(review.TargetType, review.TargetId);
        return MapToReviewDto(review);
    }

    public async Task DeleteReview(int userId, string reviewId)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null) throw new KeyNotFoundException("Review not found");
        if (review.ReviewerId != userId.ToString()) throw new UnauthorizedAccessException();
        var targetType = review.TargetType;
        var targetId = review.TargetId;
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        await UpdateTargetRating(targetType, targetId);
    }

    private async Task UpdateTargetRating(string targetType, int targetId)
    {
        var reviews = await _context.Reviews.Where(r => r.TargetType == targetType && r.TargetId == targetId).ToListAsync();
        if (reviews.Count == 0) return;
        var averageRating = reviews.Average(r => r.Score);
        if (targetType == "uni") { var uni = await _context.Universities.FindAsync(targetId); if (uni != null) { uni.Rating = Math.Round(averageRating, 2); await _context.SaveChangesAsync(); } }
        else if (targetType == "prof") { var ped = await _context.Pedagogues.FindAsync(targetId); if (ped != null) { ped.Rating = Math.Round(averageRating, 2); await _context.SaveChangesAsync(); } }
    }
}

