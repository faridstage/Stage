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
    public class AntiquesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AntiquesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Antiques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antiques.ToListAsync());
        }
        public async Task<IActionResult> Index_d()
        {
            return View(await _context.Antiques.ToListAsync());
        }

        // GET: Antiques/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("id,Name,date,madein,creator,owner,ownercerti,imageurl,des,info,note")] Antiques antiques, IFormFile AntiqImage)
        {
            if (ModelState.IsValid)
            {
                if (AntiqImage != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(AntiqImage.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\AntiqImage\\" + imgName;
                    antiques.imageurl = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    AntiqImage.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    antiques.imageurl = "\\AntiqImage\\NoImage.jpeg";
                }
                _context.Add(antiques);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antiques);
        }

        // GET: Antiques/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,date,madein,creator,owner,ownercerti,imageurl,des,info,note")] Antiques antiques, IFormFile? imageFile)
        {
            if (id != antiques.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    if (antiques.imageurl != "\\AntiqImage\\NoImage.jpeg")
                    {
                        string OldimgPath = webHostEnvironment.WebRootPath + antiques.imageurl;

                        if (System.IO.File.Exists(OldimgPath))
                        {
                            System.IO.File.Delete(OldimgPath);
                        }
                    }
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\AntiqImage\\" + imgName;
                    antiques.imageurl = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();
                }

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
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antiques = await _context.Antiques.FindAsync(id);
            _context.Antiques.Remove(antiques);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntiquesExists(int id)
        {
            return _context.Antiques.Any(e => e.id == id);
        }

        //public ActionResult Search(string searchname)
        //{
        //    //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
        //    var result = _context.Antiques.Where(b => b.Name.Contains(searchname)
        //                 || b.madein.Contains(searchname)).ToList();

        //    return View(result);
        //}

        public ActionResult Search(string searchname)
        {
            List<Antiques> Book = new List<Antiques>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.Antiques.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.Antiques.Where(e => e.Name.Contains(searchname)
                        || e.madein.Contains(searchname)).ToList();
            }
            return View("Index", Book);
        }
    }
}
