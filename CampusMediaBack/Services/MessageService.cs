using CampusMediaBack.Data;
using CampusMediaBack.Models;
using CampusMediaBack.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ChatBackend.Services
{
    public class MessageService
    {
        private readonly AppDbContext _context;

        public MessageService(AppDbContext context) => _context = context;

        public async Task<Message> SendMessageAsync(int senderId, SendMessageDto dto)
        {
            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = dto.ReceiverId,
                Content = dto.Content,
                TimeSent = DateTime.UtcNow,
                IsSent = true,
                IsRead = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<List<MessageResponseDto>> GetChatHistoryAsync(int user1Id, int user2Id)
        {
            var messages = await _context.Messages
                .Where(m => (m.SenderId == user1Id && m.ReceiverId == user2Id)
                         || (m.SenderId == user2Id && m.ReceiverId == user1Id))
                .OrderBy(m => m.TimeSent)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();

            return messages.Select(m => new MessageResponseDto
            {
                Id = m.Id,
                SenderId = m.SenderId,
                ReceiverId = m.ReceiverId,
                Content = m.Content,
                TimeSent = m.TimeSent,
                IsRead = m.IsRead,
                SenderName = m.Sender?.Name ?? "",
                SenderProfileImage = m.Sender?.ProfileImage ?? ""
            }).ToList();
        }

        // Mark messages as read
        public async Task MarkMessagesAsReadAsync(int receiverId, int senderId)
        {
            var unreadMessages = await _context.Messages
                .Where(m => m.ReceiverId == receiverId && m.SenderId == senderId && !m.IsRead)
                .ToListAsync();

            foreach (var msg in unreadMessages)
                msg.IsRead = true;

            await _context.SaveChangesAsync();
        }
    }
}
