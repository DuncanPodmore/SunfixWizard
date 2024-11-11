using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunFix.Models; // Update with your actual namespace for models

namespace SunFix.Controllers
{
    public class PartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            var parts = await _context.Parts.Include(p => p.Preset).ToListAsync();
            return View(parts);
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var part = await _context.Parts
                .Include(p => p.Preset)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (part == null)
                return NotFound();

            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            ViewData["PresetId"] = new SelectList(_context.PartPresets, "Id", "Name");
            return View();
        }

        // POST: Parts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,PresetId")] Part part)
        {
            if (ModelState.IsValid)
            {
                part.CreatedAt = DateTime.Now;
                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PresetId"] = new SelectList(_context.PartPresets, "Id", "Name", part.PresetId);
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var part = await _context.Parts.FindAsync(id);
            if (part == null)
                return NotFound();

            ViewData["PresetId"] = new SelectList(_context.PartPresets, "Id", "Name", part.PresetId);
            return View(part);
        }

        // POST: Parts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,PresetId")] Part part)
        {
            if (id != part.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartExists(part.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PresetId"] = new SelectList(_context.PartPresets, "Id", "Name", part.PresetId);
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var part = await _context.Parts
                .Include(p => p.Preset)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (part == null)
                return NotFound();

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
    }
}
