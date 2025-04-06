using Microsoft.AspNetCore.Mvc;
using TicketTool.Models; 
using TicketTool.Data; 
using Microsoft.EntityFrameworkCore;

namespace TicketTool.Controllers

{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets.ToListAsync();
            return View(tickets);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }
    }
}