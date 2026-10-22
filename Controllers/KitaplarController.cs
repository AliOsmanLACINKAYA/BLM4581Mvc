using BLM4581Mvc.Data;
using BLM4581Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BLM4581Mvc.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KitapDbContext _context;

        public KitaplarController(KitapDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var kitaplar = await _context.Kitaplar
                .Include(k => k.Kategori)
                .OrderBy(k => k.Ad)
                .ToListAsync();
            return View(kitaplar);
        }
        public async Task<IActionResult> Detay(int id)
        {
            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .FirstOrDefaultAsync(k => k.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            await KategorileriDoldurAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ekle(Kitap kitap)
        {
            if (!ModelState.IsValid)
            {
                await KategorileriDoldurAsync();
                return View(kitap);
            }
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = $"\"{kitap.Ad}\" eklendi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Duzenle(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            await KategorileriDoldurAsync();
            return View(kitap);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Duzenle(Kitap kitap)
        {
            if (!ModelState.IsValid)
            {
                await KategorileriDoldurAsync();
                return View(kitap);
            }
            _context.Kitaplar.Update(kitap);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = $"\"{kitap.Ad}\" güncellendi.";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Sil(int id)
        {
            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .FirstOrDefaultAsync(k => k.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
        }


        [HttpPost, ActionName("Sil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SilOnay(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
            TempData["Mesaj"] = $"\"{kitap.Ad}\" silindi.";
            return RedirectToAction(nameof(Index));
        }


        private async Task KategorileriDoldurAsync()
        {
            var kategoriler = await _context.Kategoriler
                .OrderBy(k => k.Ad)
                .ToListAsync();
            ViewBag.Kategoriler = new SelectList(kategoriler, "Id", "Ad");
        }

    }
}
