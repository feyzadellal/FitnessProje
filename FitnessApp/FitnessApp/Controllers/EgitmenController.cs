using Microsoft.AspNetCore.Mvc;
using FitnessApp.Data;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    public class EgitmenController : Controller
    {
        private readonly AppDbContext _context;

        public EgitmenController(AppDbContext context)
        {
            _context = context;
        }

        // Eğitmenleri Listeleme (Salon bilgisiyle beraber)
        public async Task<IActionResult> Index()
        {
            // Include(e => e.Salon) komutu çok önemli!
            // Bu komut, "Eğitmeni getirirken çalıştığı Salonun adını da getir" demektir.
            // İlişkisel veritabanı (Foreign Key) işte burada işe yarar.
            var egitmenler = await _context.Egitmenler.Include(e => e.Salon).ToListAsync();
            return View(egitmenler);
        }
    }
}