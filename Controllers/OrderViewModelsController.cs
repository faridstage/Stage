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
    public class OrderViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderViewModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orderViewModel.Include(o => o.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderViewModel = await _context.orderViewModel
                .Include(o => o.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }

        // GET: OrderViewModels/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "Name");
            return View();
        }

        // POST: OrderViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Whatsapp_phone,Other_way_Contact,Book_name,Address,BookId")] OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderViewModel);
                await _context.SaveChangesAsync();
               return RedirectToAction("Create","OrderViewModel");
            }
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "Name", orderViewModel.BookId);
            return View(orderViewModel);
        }

        // GET: OrderViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderViewModel = await _context.orderViewModel.FindAsync(id);
            if (orderViewModel == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "Name", orderViewModel.BookId);
            return View(orderViewModel);
        }

        // POST: OrderViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Whatsapp_phone,Other_way_Contact,Book_name,Address,BookId")] OrderViewModel orderViewModel)
        {
            if (id != orderViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderViewModelExists(orderViewModel.Id))
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
            ViewData["BookId"] = new SelectList(_context.Books, "ID", "Name", orderViewModel.BookId);
            return View(orderViewModel);
        }

        // GET: OrderViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderViewModel = await _context.orderViewModel
                .Include(o => o.Book)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderViewModel == null)
            {
                return NotFound();
            }

            return View(orderViewModel);
        }

        // POST: OrderViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderViewModel = await _context.orderViewModel.FindAsync(id);
            _context.orderViewModel.Remove(orderViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderViewModelExists(int id)
        {
            return _context.orderViewModel.Any(e => e.Id == id);
        }
    }
}
