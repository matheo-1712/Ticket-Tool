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
    
    [HttpGet]
    public async Task<IActionResult> GetAllTickets()
    {
        var tickets = await _context.Tickets
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        return Ok(tickets);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromForm] Ticket ticket)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Ticket créé avec succès", id = ticket.Id });
    }
}