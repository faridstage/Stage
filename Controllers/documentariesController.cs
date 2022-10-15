using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList.Mvc.Core;
using X.PagedList;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;


namespace Stage_Books.Controllers
{
    public class documentariesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public documentariesController(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: documentaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.documentaries.ToListAsync());
        }

        // GET: documentaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentaries = await _context.documentaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentaries == null)
            {
                return NotFound();
            }

            return View(documentaries);
        }

        // GET: documentaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: documentaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DocName,Produce,Category,Publisher,PubDate,Language,Rights,pathdocFile,ImageURL,note")] documentaries documentaries, IFormFile docmov, IFormFile docimg)
        {
            if (ModelState.IsValid)
            {
                if (docmov != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(docmov.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\documentariesmovie\\" + imgName;
                    documentaries.pathdocFile = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    docmov.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    documentaries.pathdocFile = "\\documentariesmovie\\NoImage.jpeg";
                }
                if (docimg != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(docimg.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\documentariesimg\\" + imgName;
                    documentaries.ImageURL = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    docimg.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    documentaries.ImageURL = "\\documentariesimg\\NoImage.jpeg";
                }
                _context.Add(documentaries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentaries);
        }

        // GET: documentaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentaries = await _context.documentaries.FindAsync(id);
            if (documentaries == null)
            {
                return NotFound();
            }
            return View(documentaries);
        }

        // POST: documentaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DocName,Produce,Category,Publisher,PubDate,Language,Rights,pathdocFile,ImageURL,note")] documentaries documentaries,
            IFormFile imageFile)
        {
            if (id != documentaries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    if (documentaries.ImageURL != "\\documentariesimg\\NoImage.jpeg")
                    {
                        string OldimgPath = webHostEnvironment.WebRootPath + documentaries.ImageURL;

                        if (System.IO.File.Exists(OldimgPath))
                        {
                            System.IO.File.Delete(OldimgPath);
                        }
                    }
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\documentariesimg\\" + imgName;
                    documentaries.ImageURL = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();
                }


                try
                {
                    _context.Update(documentaries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!documentariesExists(documentaries.Id))
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
            return View(documentaries);
        }

        // GET: documentaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentaries = await _context.documentaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentaries == null)
            {
                return NotFound();
            }

            return View(documentaries);
        }

        // POST: documentaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentaries = await _context.documentaries.FindAsync(id);
            _context.documentaries.Remove(documentaries);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool documentariesExists(int id)
        {
            return _context.documentaries.Any(e => e.Id == id);
        }

        [HttpPost]
        //public ActionResult Search(string searchname)
        //{
        //    //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
        //    var result = _context.documentaries.Where(b => b.DocName.Contains(searchname)
        //                 || b.Publisher.Contains(searchname)
        //                 || b.Category.Contains(searchname)).ToList();

        //    return View(result);
        //}

        public ActionResult Search(string searchname)
        {
            List<documentaries> Book = new List<documentaries>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.documentaries.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.documentaries.Where(e => e.DocName.Contains(searchname)
                        || e.Publisher.Contains(searchname)
                        || e.Category.Contains(searchname)).ToList();
            }
            return View("Index", Book);
        }
    }
}
