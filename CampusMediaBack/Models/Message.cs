namespace CampusMediaBack.Models
{
    public class Message
    {
        public int Id { get; set; }

        // Foreign Keys
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public string Content { get; set; } = string.Empty;

        public DateTime TimeSent { get; set; } = DateTime.UtcNow;

        public bool IsSent { get; set; } = false;

        public bool IsRead { get; set; } = false;

        // Navigation Properties (optional for queries)
        public virtual User? Sender { get; set; }
        public virtual User? Receiver { get; set; }
    }
}
