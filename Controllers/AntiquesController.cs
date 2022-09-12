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
    public class AntiquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AntiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Antiques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antiques.ToListAsync());
        }
        
        public async Task<IActionResult> IndexShow()
        {
            return View(await _context.Antiques.ToListAsync());
        }
        // GET: Antiques/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiques = await _context.Antiques
                .FirstOrDefaultAsync(m => m.id == id);
            if (antiques == null)
            {
                return NotFound();
            }

            return View(antiques);
        }

        // GET: Antiques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,date,madein,creator,owner,ownercerti,imageurl,des,info,note")] Antiques antiques)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antiques);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antiques);
        }

        // GET: Antiques/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiques = await _context.Antiques.FindAsync(id);
            if (antiques == null)
            {
                return NotFound();
            }
            return View(antiques);
        }

        // POST: Antiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,Name,date,madein,creator,owner,ownercerti,imageurl,des,info,note")] Antiques antiques)
        {
            if (id != antiques.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antiques);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntiquesExists(antiques.id))
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
            return View(antiques);
        }

        // GET: Antiques/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antiques = await _context.Antiques
                .FirstOrDefaultAsync(m => m.id == id);
            if (antiques == null)
            {
                return NotFound();
            }

            return View(antiques);
        }

        // POST: Antiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var antiques = await _context.Antiques.FindAsync(id);
            _context.Antiques.Remove(antiques);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntiquesExists(string id)
        {
            return _context.Antiques.Any(e => e.id == id);
        }
    }
}
