using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;

namespace Stage_Books.Controllers
{
    public class SaveBooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment WebHostEnvironment;

        public SaveBooksController(ApplicationDbContext context, IWebHostEnvironment webHostEnv)
        {
            _context = context;
            WebHostEnvironment = webHostEnv;
        }

        // GET: SaveBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Saved.ToListAsync());
        }

        // GET: SaveBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saveBook = await _context.Saved
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saveBook == null)
            {
                return NotFound();
            }

            return View(saveBook);
        }

        // GET: SaveBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaveBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,bookDesc")] SaveBook saveBook,IFormFile ImageURL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saveBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saveBook);
        }

        // GET: SaveBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saveBook = await _context.Saved.FindAsync(id);
            if (saveBook == null)
            {
                return NotFound();
            }
            return View(saveBook);
        }

        // POST: SaveBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,bookDesc,ImageURL")] SaveBook saveBook)
        {
            if (id != saveBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saveBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaveBookExists(saveBook.Id))
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
            return View(saveBook);
        }

        // GET: SaveBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saveBook = await _context.Saved
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saveBook == null)
            {
                return NotFound();
            }

            return View(saveBook);
        }

        // POST: SaveBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saveBook = await _context.Saved.FindAsync(id);
            _context.Saved.Remove(saveBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaveBookExists(int id)
        {
            return _context.Saved.Any(e => e.Id == id);
        }
    }
}
