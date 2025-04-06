using Microsoft.AspNetCore.Mvc;
using TicketTool.Models; 
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TicketTool.Controllers
{
    public class TicketController : Controller
    {
        private readonly HttpClient _httpClient;

        public TicketController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("https://support.perodeau-matheo.xyz/api/ticket");
            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(response);
            return View(tickets);
        }

        public IActionResult New()
        {
            return View();
        }
    }
}