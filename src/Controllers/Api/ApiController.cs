using Microsoft.AspNetCore.Mvc;
using TicketTool.Models;
using TicketTool.Data;
using Microsoft.EntityFrameworkCore;


namespace TicketTool.Controllers;

[ApiController]
[Route("api/ticket")]
public class ApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApiController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // Affichage de l'ensemble des tickets
    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _context.Tickets
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        return Ok(tickets);
    }
    
    // Affichage d'un ticket par rapport à son ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicketById(int id)
    {
        var ticket = await _context.Tickets
            .FirstOrDefaultAsync(t => t.Id == id);
        
        if (ticket == null)
        {
            return NotFound(new { message = "Ticket non trouvé" });
        }

        return Ok(ticket);
    }
    
    // Création d'un ticket
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromForm] Ticket ticket)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Ticket créé avec succès", id = ticket.Id });
    }
    
    // Modification d'un ticket via le formulaire TODO : Refaire ça en PUT
    [HttpPost("update/{id}")]
    public async Task<IActionResult> UpdateTicket(int id, [FromForm] Ticket ticket)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingTicket = await _context.Tickets.FindAsync(id);
        if (existingTicket == null)
        {
            return NotFound(new { message = "Ticket non trouvé" });
        }

        existingTicket.Username = ticket.Username;
        existingTicket.Title = ticket.Title;
        existingTicket.Description = ticket.Description;
        existingTicket.Email = ticket.Email;
        existingTicket.Statut = ticket.Statut;

        await _context.SaveChangesAsync();
        
        return Ok(new { message = "Ticket modifié avec succès", id = existingTicket.Id });
    }
    
    // Suppression d'un ticket
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
        {
            return NotFound(new { message = "Ticket non trouvé" });
        }
        
        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
        
        return Ok(new { message = "Ticket supprimé avec succès" });
    }
    
    


    
    
}