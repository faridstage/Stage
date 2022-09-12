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
    public class IssuancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssuancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Issuances
        public async Task<IActionResult> Index()
        {
            return View(await _context.issuance.ToListAsync());
        }

        // GET: Issuances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuance = await _context.issuance
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (issuance == null)
            {
                return NotFound();
            }

            return View(issuance);
        }

        // GET: Issuances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issuances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pid,Issuancedate,Pages,IssuanceNumber,Nid,note")] Issuance issuance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issuance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issuance);
        }

        // GET: Issuances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuance = await _context.issuance.FindAsync(id);
            if (issuance == null)
            {
                return NotFound();
            }
            return View(issuance);
        }

        // POST: Issuances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pid,Issuancedate,Pages,IssuanceNumber,Nid,note")] Issuance issuance)
        {
            if (id != issuance.Pid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issuance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssuanceExists(issuance.Pid))
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
            return View(issuance);
        }

        // GET: Issuances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var issuance = await _context.issuance
                .FirstOrDefaultAsync(m => m.Pid == id);
            if (issuance == null)
            {
                return NotFound();
            }

            return View(issuance);
        }

        // POST: Issuances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issuance = await _context.issuance.FindAsync(id);
            _context.issuance.Remove(issuance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssuanceExists(int id)
        {
            return _context.issuance.Any(e => e.Pid == id);
        }
    }
}
