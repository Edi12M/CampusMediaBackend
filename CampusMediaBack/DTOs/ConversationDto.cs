namespace CampusMediaBack.DTOs
{
    public class ConversationDto
    {
        public int ConversationId { get; set; } // Can be last message ID for simplicity
        public UserConversationDto OtherUser { get; set; } = null!;
        public string LastMessage { get; set; } = string.Empty;
        public DateTime LastMessageTime { get; set; }
        public int UnreadCount { get; set; } = 0;
    }

    public class UserConversationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
    }
}
