using Microsoft.AspNetCore.Mvc;
using TicketTool.Models;
using TicketTool.Data;

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