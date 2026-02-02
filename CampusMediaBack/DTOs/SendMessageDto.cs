namespace CampusMediaBack.DTOs
{
    public class SendMessageDto
    {
        public int ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    /// <summary>Message with sender info for display (name, profile image).</summary>
    public class MessageResponseDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime TimeSent { get; set; }
        public bool IsRead { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderProfileImage { get; set; } = string.Empty;
    }
}
