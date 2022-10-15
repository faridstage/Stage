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
    public class AudioBooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public AudioBooksController(ApplicationDbContext context , IWebHostEnvironment WebHostEnvironment)
        {
            _context = context;
            this.WebHostEnvironment = WebHostEnvironment;
        }
        // GET: Books/Search/5
        public IActionResult Search(string? search)
        {
            List<AudioBook> AudioBook = new List<AudioBook>();
            if (string.IsNullOrEmpty(search))
            {
                AudioBook = _context.AudioBooks.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                AudioBook = _context.AudioBooks.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("indexdash", AudioBook); ;
        }

        // GET: Books/Search/5
        public IActionResult Search2(string? search)
        {
            List<AudioBook> AudioBook = new List<AudioBook>();
            if (string.IsNullOrEmpty(search))
            {
                AudioBook = _context.AudioBooks.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                AudioBook = _context.AudioBooks.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index", AudioBook); ;
        }
        // GET: AudioBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AudioBooks.ToListAsync());
        }
        public async Task<IActionResult> Indexdash()
        {
            return View(await _context.AudioBooks.ToListAsync());
        }
        // GET: AudioBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioBook = await _context.AudioBooks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (audioBook == null)
            {
                return NotFound();
            }

            return View(audioBook);
        }

        // GET: AudioBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AudioBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Author,Category,Publisher,Desc,PubDate,uploadDate,Language,Topic,Rights,path,ImageURL,note")] AudioBook audioBook, IFormFile imageFile, IFormFile audiofile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\AudioImages\\" + imgName;
                    audioBook.ImageURL = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();
                }
                else
                {
                    audioBook.ImageURL = "\\AudioImages\\NoUser.jpg";
                }
                if (audiofile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(audiofile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\audiofile\\" + imgName;
                    audioBook.path = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    audiofile.CopyTo(imgStream);
                    imgStream.Dispose();
                }
                else
                {
                    audioBook.path = "\\audiofile\\NoUser.jpg";
                }
                _context.Add(audioBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(audioBook);
        }
        // GET: AudioBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioBook = await _context.AudioBooks.FindAsync(id);
            if (audioBook == null)
            {
                return NotFound();
            }
            return View(audioBook);
        }

        // POST: AudioBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Author,Category,Publisher,Desc,PubDate,uploadDate,Language,Topic,Rights,path,ImageURL,note")] AudioBook audioBook, IFormFile imageFile)
        {
            if (id != audioBook.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    if (audioBook.ImageURL != "\\AudioImages\\NoImage.jpeg")
                    {
                        string OldimgPath = WebHostEnvironment.WebRootPath + audioBook.ImageURL;

                        if (System.IO.File.Exists(OldimgPath))
                        {
                            System.IO.File.Delete(OldimgPath);
                        }
                    }
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\AudioImages\\" + imgName;
                    audioBook.ImageURL = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();
                }


                try
                {
                    _context.Update(audioBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AudioBookExists(audioBook.ID))
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
            return View(audioBook);
        }

        // GET: AudioBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var audioBook = await _context.AudioBooks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (audioBook == null)
            {
                return NotFound();
            }

            return View(audioBook);
        }

        // POST: AudioBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AudioBook AudioBook = _context.AudioBooks.FirstOrDefault(e => e.ID == id);

            if (AudioBook.ImageURL != "\\AudioImages\\NoBook.jpg")
            {
                string imgPath = WebHostEnvironment.WebRootPath + AudioBook.ImageURL;

                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }
            var audioBook = await _context.AudioBooks.FindAsync(id);
            _context.AudioBooks.Remove(audioBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool AudioBookExists(int id)
        {
            return _context.AudioBooks.Any(e => e.ID == id);
        }

        public ActionResult SearchAudioBooks(string searchname)
        {
            List<AudioBook> Book = new List<AudioBook>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.AudioBooks.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.AudioBooks.Where(e => e.Name.Contains(searchname)
                        || e.Category.Contains(searchname)
                        || e.Topic.Contains(searchname)).ToList();
            }
            return View("Index", Book);
        }
    }
}
