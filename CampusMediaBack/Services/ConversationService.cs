using CampusMediaBack.Data;
using CampusMediaBack.DTOs;
using CampusMediaBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatBackend.Services
{
    public class ConversationService
    {
        private readonly AppDbContext _context;

        public ConversationService(AppDbContext context) => _context = context;

        public async Task<List<ConversationDto>> GetUserConversationsAsync(int userId)
        {
            var conversations = await _context.Messages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .GroupBy(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
                .Select(g => new
                {
                    OtherUserId = g.Key,
                    LastMessage = g.OrderByDescending(m => m.TimeSent).FirstOrDefault(),
                    UnreadCount = g.Count(m => m.ReceiverId == userId && !m.IsRead)
                })
                .ToListAsync();

            var result = new List<ConversationDto>();

            foreach (var convo in conversations)
            {
                var otherUser = await _context.Users.FindAsync(convo.OtherUserId);
                if (otherUser == null) continue;

                result.Add(new ConversationDto
                {
                    ConversationId = convo.LastMessage?.Id ?? 0,
                    OtherUser = new UserConversationDto
                    {
                        Id = otherUser.Id,
                        Name = otherUser.Name,
                        ProfileImage = otherUser.ProfileImage
                    },
                    LastMessage = convo.LastMessage?.Content ?? "",
                    LastMessageTime = convo.LastMessage?.TimeSent ?? DateTime.MinValue,
                    UnreadCount = convo.UnreadCount
                });
            }

            return result.OrderByDescending(c => c.LastMessageTime).ToList();
        }
    }
}
