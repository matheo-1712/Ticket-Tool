using TicketTool.Models;   
using Microsoft.EntityFrameworkCore;

namespace TicketTool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }  // Exemple d'entité (table) "Tickets"
    }
}