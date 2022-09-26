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
    public class ThesesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ThesesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Theses
        public async Task<IActionResult> Index()
        {
            return View(await _context.theses.ToListAsync());
        }

        // GET: Theses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.theses
                .FirstOrDefaultAsync(m => m.id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // GET: Theses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Theses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,owner,image,Thesisurl,date,category,lang,topic,pagesnumber,desc_info,type,note")] Thesis thesis, IFormFile thesesimg, IFormFile thesesfile)
        {
            if (ModelState.IsValid)
            {
                if (thesesimg != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(thesesimg.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\thesesimg\\" + imgName;
                    thesis.image = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    thesesimg.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    thesis.image = "\\thesesimg\\NoImage.jpeg";
                }
                if (thesesfile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(thesesfile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\thesesfile\\" + imgName;
                    thesis.Thesisurl = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    thesesfile.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    thesis.Thesisurl = "\\thesesfile\\NoImage.jpeg";
                }
                _context.Add(thesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thesis);
        }

        // GET: Theses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.theses.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }
            return View(thesis);
        }

        // POST: Theses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,owner,image,Thesisurl,date,category,lang,topic,pagesnumber,desc_info,type,note")] Thesis thesis)
        {
            if (id != thesis.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(thesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThesisExists(thesis.id))
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
            return View(thesis);
        }

        // GET: Theses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.theses
                .FirstOrDefaultAsync(m => m.id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // POST: Theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thesis = await _context.theses.FindAsync(id);
            _context.theses.Remove(thesis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThesisExists(int id)
        {
            return _context.theses.Any(e => e.id == id);
        }

        public ActionResult Searchtheses(string searchname)
        {
            List<Thesis> Book = new List<Thesis>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.theses.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.theses.Where(e => e.Name.Contains(searchname)
                        || e.category.Contains(searchname)
                        || e.topic.Contains(searchname)).ToList();
            }
            return View("Index", Book);
        }
    }
}
