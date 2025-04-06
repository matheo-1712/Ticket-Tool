namespace TicketTool.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}