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
    public class AllNewsPapersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllNewsPapersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllNewsPapers
        public async Task<IActionResult> Index()
        {
            return View(await _context.allNewsPaper.ToListAsync());
        }
        
            public async Task<IActionResult> IndexShow()
        {
            return View(await _context.allNewsPaper.ToListAsync());
        }
        // GET: AllNewsPapers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allNewsPapers = await _context.allNewsPaper
                .FirstOrDefaultAsync(m => m.Nid == id);
            if (allNewsPapers == null)
            {
                return NotFound();
            }

            return View(allNewsPapers);
        }

        // GET: AllNewsPapers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllNewsPapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nid,Name,owner,logo,newspaperdate,firstpubdate,category,lang,desc_info,type,note")] AllNewsPapers allNewsPapers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allNewsPapers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allNewsPapers);
        }

        // GET: AllNewsPapers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allNewsPapers = await _context.allNewsPaper.FindAsync(id);
            if (allNewsPapers == null)
            {
                return NotFound();
            }
            return View(allNewsPapers);
        }

        // POST: AllNewsPapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nid,Name,owner,logo,newspaperdate,firstpubdate,category,lang,desc_info,type,note")] AllNewsPapers allNewsPapers)
        {
            if (id != allNewsPapers.Nid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allNewsPapers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllNewsPapersExists(allNewsPapers.Nid))
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
            return View(allNewsPapers);
        }

        // GET: AllNewsPapers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allNewsPapers = await _context.allNewsPaper
                .FirstOrDefaultAsync(m => m.Nid == id);
            if (allNewsPapers == null)
            {
                return NotFound();
            }

            return View(allNewsPapers);
        }

        // POST: AllNewsPapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var allNewsPapers = await _context.allNewsPaper.FindAsync(id);
            _context.allNewsPaper.Remove(allNewsPapers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllNewsPapersExists(string id)
        {
            return _context.allNewsPaper.Any(e => e.Nid == id);
        }
    }
}
