using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunFix.Models;

namespace SunFix.Controllers
{
    public class QuoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Quote/Generate
        [HttpPost]
        public IActionResult GenerateQuote([FromBody] ClampData clampData)
        {
            // Basic logic to calculate a quote based on mid and end clamps
            var totalClampCost = (clampData.MidClamps * 2.50m) + (clampData.EndClamps * 3.00m);

            // Prepare the quote details (for now, just the basic clamp information)
            var quote = new
            {
                MidClamps = clampData.MidClamps,
                EndClamps = clampData.EndClamps,
                TotalCost = totalClampCost
            };

            // Return the quote as JSON
            return Json(quote);
        }
        
        // GET: Quote
        public async Task<IActionResult> Index()
        {
            var quotes = await _context.Quotes.Include(q => q.Client).ToListAsync();
            return View(quotes);
        }

        // GET: Quote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var quote = await _context.Quotes
                .Include(q => q.Client)
                .Include(q => q.QuoteParts)
                .ThenInclude(qp => qp.Part)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (quote == null)
                return NotFound();

            return View(quote);
        }

        // GET: Quote/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
            return View();
        }

        // POST: Quote/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Date,ClientId")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                quote.CreatedAt = DateTime.Now;
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", quote.ClientId);
            return View(quote);
        }

        // GET: Quote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
                return NotFound();

            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", quote.ClientId);
            return View(quote);
        }

        // POST: Quote/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Date,ClientId")] Quote quote)
        {
            if (id != quote.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", quote.ClientId);
            return View(quote);
        }

        // GET: Quote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var quote = await _context.Quotes
                .Include(q => q.Client)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (quote == null)
                return NotFound();

            return View(quote);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }
    }

    // DTO class to receive clamp data from the frontend
    public class ClampData
    {
        public int MidClamps { get; set; }
        public int EndClamps { get; set; }
    }
}