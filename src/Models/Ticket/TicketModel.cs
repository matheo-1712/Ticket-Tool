namespace TicketTool.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Username { get; set; } 
        public string Description { get; set; }
        
        public int Priority { get; set; }
        
        public int Statut { get; set; } 
        
        public string CreatedAt { get; set; }
    }
}