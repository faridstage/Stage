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
    public class magazincopysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public magazincopysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: magazincopys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.magazincopys.Include(m => m.magazines);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: magazincopys
        public async Task<IActionResult> Index_listf(int? id)
        {
            //var applicationDbContext = _context.magazincopys.Include(m => m.magazines);
            var applicationDbContext = _context.magazincopys.Include(m => m.magazines);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: magazincopys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazincopys = await _context.magazincopys
                .Include(m => m.magazines)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazincopys == null)
            {
                return NotFound();
            }

            return View(magazincopys);
        }

        // GET: magazincopys/Create
        public IActionResult Create()
        {
            ViewData["magazinesId"] = new SelectList(_context.magazines, "Id", "Name");
            return View();
        }

        // POST: magazincopys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,copydate,Pages,copyNum,magazinesId")] magazincopys magazincopys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magazincopys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["magazinesId"] = new SelectList(_context.magazines, "Id", "Name", magazincopys.magazinesId);
            return View(magazincopys);
        }

        // GET: magazincopys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazincopys = await _context.magazincopys.FindAsync(id);
            if (magazincopys == null)
            {
                return NotFound();
            }
            ViewData["magazinesId"] = new SelectList(_context.magazines, "Id", "Name", magazincopys.magazinesId);
            return View(magazincopys);
        }

        // POST: magazincopys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,copydate,Pages,copyNum,magazinesId")] magazincopys magazincopys)
        {
            if (id != magazincopys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazincopys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!magazincopysExists(magazincopys.Id))
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
            ViewData["magazinesId"] = new SelectList(_context.magazines, "Id", "Name", magazincopys.magazinesId);
            return View(magazincopys);
        }

        // GET: magazincopys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazincopys = await _context.magazincopys
                .Include(m => m.magazines)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazincopys == null)
            {
                return NotFound();
            }

            return View(magazincopys);
        }

        // POST: magazincopys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazincopys = await _context.magazincopys.FindAsync(id);
            _context.magazincopys.Remove(magazincopys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool magazincopysExists(int id)
        {
            return _context.magazincopys.Any(e => e.Id == id);
        }
    }
}
