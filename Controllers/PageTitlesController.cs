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
    public class PageTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PageTitlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PageTitles
        public async Task<IActionResult> Index()
        {
            return View(await _context.pageTitles.ToListAsync());
        }

        // GET: PageTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageTitle = await _context.pageTitles
                .FirstOrDefaultAsync(m => m.id == id);
            if (pageTitle == null)
            {
                return NotFound();
            }

            return View(pageTitle);
        }

        // GET: PageTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PageTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Titles,ppid,note")] PageTitle pageTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pageTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pageTitle);
        }

        // GET: PageTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageTitle = await _context.pageTitles.FindAsync(id);
            if (pageTitle == null)
            {
                return NotFound();
            }
            return View(pageTitle);
        }

        // POST: PageTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Titles,ppid,note")] PageTitle pageTitle)
        {
            if (id != pageTitle.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pageTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageTitleExists(pageTitle.id))
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
            return View(pageTitle);
        }

        // GET: PageTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pageTitle = await _context.pageTitles
                .FirstOrDefaultAsync(m => m.id == id);
            if (pageTitle == null)
            {
                return NotFound();
            }

            return View(pageTitle);
        }

        // POST: PageTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pageTitle = await _context.pageTitles.FindAsync(id);
            _context.pageTitles.Remove(pageTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PageTitleExists(int id)
        {
            return _context.pageTitles.Any(e => e.id == id);
        }
    }
}
