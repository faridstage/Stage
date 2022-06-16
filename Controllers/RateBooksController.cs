using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;

namespace Stage_Books.Controllers
{
    public class RateBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RateBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RateBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.RateBooks.ToListAsync());
        }

        // GET: RateBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateBook = await _context.RateBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rateBook == null)
            {
                return NotFound();
            }

            return View(rateBook);
        }

        // GET: RateBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RateBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rate")] RateBook rateBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rateBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rateBook);
        }

        // GET: RateBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateBook = await _context.RateBooks.FindAsync(id);
            if (rateBook == null)
            {
                return NotFound();
            }
            return View(rateBook);
        }

        // POST: RateBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rate")] RateBook rateBook)
        {
            if (id != rateBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rateBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RateBookExists(rateBook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rateBook);
        }

        // GET: RateBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rateBook = await _context.RateBooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rateBook == null)
            {
                return NotFound();
            }

            return View(rateBook);
        }

        // POST: RateBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rateBook = await _context.RateBooks.FindAsync(id);
            _context.RateBooks.Remove(rateBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RateBookExists(int id)
        {
            return _context.RateBooks.Any(e => e.Id == id);
        }
    }
}
