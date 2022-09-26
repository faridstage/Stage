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
    public class AllNewsPapersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AllNewsPapersController(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: AllNewsPapers
        public async Task<IActionResult> Index()
        {
            return View(await _context.allNewsPaper.ToListAsync());
        }

        // GET: AllNewsPapers/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Nid,Name,owner,Country,logo,newspaperdate,firstpubdate,category,lang,desc_info,type,note")] AllNewsPapers allNewsPapers , IFormFile newspaperlogoimg)
        {
            if (ModelState.IsValid)
            {
                if (newspaperlogoimg != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(newspaperlogoimg.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\newspaperlogoimg\\" + imgName;
                    allNewsPapers.logo = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    newspaperlogoimg.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    allNewsPapers.logo = "\\newspaperlogoimg\\NoImage.jpeg";
                }
                _context.Add(allNewsPapers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allNewsPapers);
        }

        // GET: AllNewsPapers/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("Nid,Name,owner,Country,logo,newspaperdate,firstpubdate,category,lang,desc_info,type,note")] AllNewsPapers allNewsPapers)
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
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allNewsPapers = await _context.allNewsPaper.FindAsync(id);
            _context.allNewsPaper.Remove(allNewsPapers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllNewsPapersExists(int id)
        {
            return _context.allNewsPaper.Any(e => e.Nid == id);
        }
    }
}
