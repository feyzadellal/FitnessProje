using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; // Bu satır o hatayı çözen kilit nokta!
using FitnessApp.Data;
using FitnessApp.Models;

namespace FitnessApp.Controllers
{
    public class HizmetController : Controller
    {
        private readonly AppDbContext _context;

        public HizmetController(AppDbContext context)
        {
            _context = context;
        }

        // 1. LİSTELEME (INDEX)
        public async Task<IActionResult> Index()
        {
            var hizmetler = await _context.Hizmetler.Include(h => h.Salon).ToListAsync();
            return View(hizmetler);
        }

        // 2. YENİ EKLEME SAYFASI (CREATE - GET)
        public IActionResult Create()
        {
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "Ad");
            return View();
        }

        // 3. YENİ KAYDETME İŞLEMİ (CREATE - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hizmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "Ad", hizmet.SalonId);
            return View(hizmet);
        }

        // 4. DÜZENLEME SAYFASI (EDIT - GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hizmet = await _context.Hizmetler.FindAsync(id);
            if (hizmet == null) return NotFound();

            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "Ad", hizmet.SalonId);
            return View(hizmet);
        }

        // 5. DÜZENLEME KAYDETME İŞLEMİ (EDIT - POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Hizmet hizmet)
        {
            if (id != hizmet.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hizmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Hizmetler.Any(e => e.Id == hizmet.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "Ad", hizmet.SalonId);
            return View(hizmet);
        }

        // 6. SİLME SAYFASI (DELETE - GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hizmet = await _context.Hizmetler
                .Include(h => h.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (hizmet == null) return NotFound();

            return View(hizmet);
        }

        // 7. SİLME ONAYI (DELETE - POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hizmet = await _context.Hizmetler.FindAsync(id);
            if (hizmet != null)
            {
                _context.Hizmetler.Remove(hizmet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}