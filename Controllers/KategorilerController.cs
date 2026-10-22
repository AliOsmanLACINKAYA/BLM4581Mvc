using BLM4581Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BLM4581Mvc.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly KitapDbContext _context;

        public KategorilerController(KitapDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kategoriler = await _context.Kategoriler
                .Include(k => k.Kitaplar)
                .OrderBy(k => k.Ad)
                .ToListAsync();
            return View(kategoriler);
        }
        public async Task<IActionResult> Detay(int id)
        {
            var kategori = await _context.Kategoriler
                .Include(k => k.Kitaplar)
                .FirstOrDefaultAsync(k => k.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }
    }
}
