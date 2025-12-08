using Microsoft.AspNetCore.Mvc;
using FitnessApp.Data;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Controllers
{
    public class SalonController : Controller
    {
        private readonly AppDbContext _context;

        public SalonController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME SAYFASI (Index)
        public async Task<IActionResult> Index()
        {
            var salonlar = await _context.Salonlar.ToListAsync();
            return View(salonlar);
        }

        // 2. EKLEME SAYFASI (Create) - Formu Gösterir
        public IActionResult Create()
        {
            return View();
        }

        // 3. EKLEME İŞLEMİ (Create) - Formdan Gelen Veriyi Kaydeder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salon);
        }
    }
}