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
    public class ArchaeologiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArchaeologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Archaeologies
        public async Task<IActionResult> Index()
        {
            return View(await _context.archaeology.ToListAsync());
        }

        public async Task<IActionResult> IndexShow()
        {
            return View(await _context.archaeology.ToListAsync());
        }
        // GET: Archaeologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archaeology = await _context.archaeology
                .FirstOrDefaultAsync(m => m.id == id);
            if (archaeology == null)
            {
                return NotFound();
            }

            return View(archaeology);
        }

        // GET: Archaeologies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Archaeologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Country,City,date,creator,exename,info,place,code,imageurl,note")] Archaeology archaeology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archaeology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archaeology);
        }

        // GET: Archaeologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archaeology = await _context.archaeology.FindAsync(id);
            if (archaeology == null)
            {
                return NotFound();
            }
            return View(archaeology);
        }

        // POST: Archaeologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Country,City,date,creator,exename,info,place,code,imageurl,note")] Archaeology archaeology)
        {
            if (id != archaeology.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archaeology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchaeologyExists(archaeology.id))
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
            return View(archaeology);
        }

        // GET: Archaeologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archaeology = await _context.archaeology
                .FirstOrDefaultAsync(m => m.id == id);
            if (archaeology == null)
            {
                return NotFound();
            }

            return View(archaeology);
        }

        // POST: Archaeologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var archaeology = await _context.archaeology.FindAsync(id);
            _context.archaeology.Remove(archaeology);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchaeologyExists(int id)
        {
            return _context.archaeology.Any(e => e.id == id);
        }
    }
}
