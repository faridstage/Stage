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
    public class magazinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public magazinesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: magazines
        public async Task<IActionResult> Index()
        {
            return View(await _context.magazines.ToListAsync());
        }

        // GET: magazines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazines = await _context.magazines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazines == null)
            {
                return NotFound();
            }

            return View(magazines);
        }

        // GET: magazines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: magazines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,owner,Country,logo,startdate,firstpubdate,category,lang,desc_info")] magazines magazines, IFormFile magazinesimg)
        {
            if (ModelState.IsValid)
            {
                if (magazinesimg != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(magazinesimg.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\magazinesimg\\" + imgName;
                    magazines.logo = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    magazinesimg.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    magazines.logo = "\\magazinesimg\\NoImage.jpeg";
                }
                _context.Add(magazines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magazines);
        }

        // GET: magazines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazines = await _context.magazines.FindAsync(id);
            if (magazines == null)
            {
                return NotFound();
            }
            return View(magazines);
        }

        // POST: magazines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,owner,Country,logo,startdate,firstpubdate,category,lang,desc_info")] magazines magazines, IFormFile magazinesimg)
        {
            if (id != magazines.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magazines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!magazinesExists(magazines.Id))
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
            return View(magazines);
        }

        // GET: magazines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazines = await _context.magazines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (magazines == null)
            {
                return NotFound();
            }

            return View(magazines);
        }

        // POST: magazines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var magazines = await _context.magazines.FindAsync(id);
            _context.magazines.Remove(magazines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool magazinesExists(int id)
        {
            return _context.magazines.Any(e => e.Id == id);
        }
    }
}
