using Microsoft.AspNetCore.Mvc;
using FitnessApp.Data;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    public class HizmetController : Controller
    {
        private readonly AppDbContext _context;

        public HizmetController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Hizmetleri getirirken hangi salona ait olduğunu da getir (İlişkisel Veri)
            var hizmetler = await _context.Hizmetler.Include(h => h.Salon).ToListAsync();
            return View(hizmetler);
        }
    }
}