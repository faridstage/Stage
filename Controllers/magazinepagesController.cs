using System;
using System.Collections.Generic;
using System.IO;
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
    public class magazinepagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public magazinepagesController(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: magazinepages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.magazinepages.Include(m => m.magazincopys);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: magazinepages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazinepages = await _context.magazinepages
                .Include(m => m.magazincopys)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazinepages == null)
            {
                return NotFound();
            }

            return View(magazinepages);
        }

        // GET: magazinepages/Create
        public IActionResult Create()
        {
            ViewData["magazincopysId"] = new SelectList(_context.magazincopys, "Id", "Id");
            return View();
        }

        // POST: magazinepages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,pageNum,magazincopysId,page")] magazinepages magazinepages, IFormFile magazinepagesimg)
        {
            
            if (ModelState.IsValid)
            {
                if (magazinepagesimg != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(magazinepagesimg.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\magazinepagesimg\\" + imgName;
                    magazinepages.page = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    magazinepagesimg.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    magazinepages.page = "\\magazinepagesimg\\NoImage.jpeg";
                }
                _context.Add(magazinepages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["magazincopysId"] = new SelectList(_context.magazincopys, "Id", "Id", magazinepages.magazincopysId);
            return View(magazinepages);
        }

        // GET: magazinepages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazinepages = await _context.magazinepages.FindAsync(id);
            if (magazinepages == null)
            {
                return NotFound();
            }
            ViewData["magazincopysId"] = new SelectList(_context.magazincopys, "Id", "Id", magazinepages.magazincopysId);
            return View(magazinepages);
        }

        // POST: magazinepages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,pageNum,magazincopysId,page")] magazinepages magazinepages, IFormFile magazinepagesimg)
        {
            if (id != magazinepages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazinepages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!magazinepagesExists(magazinepages.Id))
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
            ViewData["magazincopysId"] = new SelectList(_context.magazincopys, "Id", "Id", magazinepages.magazincopysId);
            return View(magazinepages);
        }

        // GET: magazinepages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazinepages = await _context.magazinepages
                .Include(m => m.magazincopys)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazinepages == null)
            {
                return NotFound();
            }

            return View(magazinepages);
        }

        // POST: magazinepages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazinepages = await _context.magazinepages.FindAsync(id);
            _context.magazinepages.Remove(magazinepages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool magazinepagesExists(int id)
        {
            return _context.magazinepages.Any(e => e.Id == id);
        }
    }
}
