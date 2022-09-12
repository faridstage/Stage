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
    public class AdvRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdvRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.advRequest.Include(a => a.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AdvRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advRequest = await _context.advRequest
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (advRequest == null)
            {
                return NotFound();
            }

            return View(advRequest);
        }

        // GET: AdvRequests/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AdvRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Phone,OtherWay,DateRequest,BookName,Description,Author,Topic,Language,Price,PlaceBook,LongTime,Start,End,BookCover,BookFile,UserId")] AdvRequest advRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", advRequest.UserId);
            return View(advRequest);
        }

        // GET: AdvRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advRequest = await _context.advRequest.FindAsync(id);
            if (advRequest == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", advRequest.UserId);
            return View(advRequest);
        }

        // POST: AdvRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Phone,OtherWay,DateRequest,BookName,Description,Author,Topic,Language,Price,PlaceBook,LongTime,Start,End,BookCover,BookFile,UserId")] AdvRequest advRequest)
        {
            if (id != advRequest.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvRequestExists(advRequest.id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", advRequest.UserId);
            return View(advRequest);
        }

        // GET: AdvRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advRequest = await _context.advRequest
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.id == id);
            if (advRequest == null)
            {
                return NotFound();
            }

            return View(advRequest);
        }

        // POST: AdvRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advRequest = await _context.advRequest.FindAsync(id);
            _context.advRequest.Remove(advRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvRequestExists(int id)
        {
            return _context.advRequest.Any(e => e.id == id);
        }
    }
}
