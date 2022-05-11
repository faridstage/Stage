using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;
using Stage_Books.Models.Encyclopedia;

namespace Stage_Books.Controllers
{
    public class EncsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EncsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Encs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Encs.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Encs.ToListAsync());
        }

        // GET: Encs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enc = await _context.Encs
                .FirstOrDefaultAsync(m => m.id == id);
            if (enc == null)
            {
                return NotFound();
            }

            return View(enc);
        }

        // GET: Encs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,FullName,Description,Category,Store,Poster")] Enc enc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enc);
        }

        // GET: Encs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enc = await _context.Encs.FindAsync(id);
            if (enc == null)
            {
                return NotFound();
            }
            return View(enc);
        }

        // POST: Encs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,FullName,Description,Category,Store,Poster")] Enc enc)
        {
            if (id != enc.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncExists(enc.id))
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
            return View(enc);
        }

        // GET: Encs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enc = await _context.Encs
                .FirstOrDefaultAsync(m => m.id == id);
            if (enc == null)
            {
                return NotFound();
            }

            return View(enc);
        }

        // POST: Encs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enc = await _context.Encs.FindAsync(id);
            _context.Encs.Remove(enc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncExists(int id)
        {
            return _context.Encs.Any(e => e.id == id);
        }
    }
}
