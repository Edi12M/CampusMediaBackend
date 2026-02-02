using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusMediaBack.Services;

public class FriendRequestService
{
    private readonly AppDbContext _context;

    public FriendRequestService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FriendRequest> SendRequest(int senderId, int receiverId)
    {
        if (senderId == receiverId)
            throw new InvalidOperationException("Cannot send friend request to yourself");

        var sender = await _context.Users.FindAsync(senderId);
        var receiver = await _context.Users.FindAsync(receiverId);

        if (sender == null || receiver == null)
            throw new InvalidOperationException("User not found");

        // Check if already friends
        if (sender.Friends.Contains(receiverId))
            throw new InvalidOperationException("Already friends with this user");

        // Check if request already exists (in either direction)
        var existingRequest = await _context.FriendRequests
            .FirstOrDefaultAsync(r => 
                r.Status == "pending" &&
                ((r.SenderId == senderId && r.ReceiverId == receiverId) ||
                 (r.SenderId == receiverId && r.ReceiverId == senderId)));

        if (existingRequest != null)
            throw new InvalidOperationException("Friend request already exists");

        var request = new FriendRequest
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Status = "pending",
            CreatedAt = DateTime.UtcNow
        };

        _context.FriendRequests.Add(request);
        await _context.SaveChangesAsync();

        return request;
    }

    public async Task<List<FriendRequestDto>> GetPendingRequests(int userId)
    {
        return await _context.FriendRequests
            .Where(r => r.ReceiverId == userId && r.Status == "pending")
            .Include(r => r.Sender)
            .Select(r => new FriendRequestDto
            {
                Id = r.Id,
                UserId = r.SenderId,
                Name = r.Sender.Name,
                ProfileImage = r.Sender.ProfileImage,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<List<FriendRequestDto>> GetSentRequests(int userId)
    {
        return await _context.FriendRequests
            .Where(r => r.SenderId == userId && r.Status == "pending")
            .Include(r => r.Receiver)
            .Select(r => new FriendRequestDto
            {
                Id = r.Id,
                UserId = r.ReceiverId,
                Name = r.Receiver.Name,
                ProfileImage = r.Receiver.ProfileImage,
                CreatedAt = r.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<FriendRequestStatusDto> GetRequestStatus(int userId, int otherUserId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
            return new FriendRequestStatusDto { Status = null };

        // Check if already friends
        if (user.Friends.Contains(otherUserId))
            return new FriendRequestStatusDto { Status = "friends" };

        // Check for pending request sent by current user
        var sentRequest = await _context.FriendRequests
            .FirstOrDefaultAsync(r => r.SenderId == userId && r.ReceiverId == otherUserId && r.Status == "pending");
        
        if (sentRequest != null)
            return new FriendRequestStatusDto { Status = "sent", RequestId = sentRequest.Id };

        // Check for pending request received by current user
        var receivedRequest = await _context.FriendRequests
            .FirstOrDefaultAsync(r => r.SenderId == otherUserId && r.ReceiverId == userId && r.Status == "pending");
        
        if (receivedRequest != null)
            return new FriendRequestStatusDto { Status = "received", RequestId = receivedRequest.Id };

        return new FriendRequestStatusDto { Status = null };
    }

    public async Task AcceptRequest(int requestId, int userId)
    {
        var request = await _context.FriendRequests.FindAsync(requestId);
        
        if (request == null)
            throw new InvalidOperationException("Friend request not found");

        if (request.ReceiverId != userId)
            throw new UnauthorizedAccessException("Not authorized to accept this request");

        if (request.Status != "pending")
            throw new InvalidOperationException("Request is no longer pending");

        var sender = await _context.Users.FindAsync(request.SenderId);
        var receiver = await _context.Users.FindAsync(request.ReceiverId);

        if (sender == null || receiver == null)
            throw new InvalidOperationException("User not found");

        // Add each other as friends
        if (!sender.Friends.Contains(receiver.Id))
            sender.Friends.Add(receiver.Id);
        
        if (!receiver.Friends.Contains(sender.Id))
            receiver.Friends.Add(sender.Id);

        request.Status = "accepted";

        await _context.SaveChangesAsync();
    }

    public async Task RejectRequest(int requestId, int userId)
    {
        var request = await _context.FriendRequests.FindAsync(requestId);
        
        if (request == null)
            throw new InvalidOperationException("Friend request not found");

        if (request.ReceiverId != userId)
            throw new UnauthorizedAccessException("Not authorized to reject this request");

        if (request.Status != "pending")
            throw new InvalidOperationException("Request is no longer pending");

        request.Status = "rejected";
        await _context.SaveChangesAsync();
    }

    public async Task CancelRequest(int requestId, int userId)
    {
        var request = await _context.FriendRequests.FindAsync(requestId);
        
        if (request == null)
            throw new InvalidOperationException("Friend request not found");

        if (request.SenderId != userId)
            throw new UnauthorizedAccessException("Not authorized to cancel this request");

        if (request.Status != "pending")
            throw new InvalidOperationException("Request is no longer pending");

        _context.FriendRequests.Remove(request);
        await _context.SaveChangesAsync();
    }
}
