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
using Stage_Books.Models.Encyclopedia;
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace Stage_Books.Controllers
{
    public class EncsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment WebHostEnvironment;
        public EncsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Books/Search/5
        public IActionResult Search(string? search)
        {
            List<Enc> Enc = new List<Enc>();
            if (string.IsNullOrEmpty(search))
            {
                Enc = _context.Encs.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                Enc = _context.Encs.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index", Enc); ;
        }
        public IActionResult Searchs(string? search)
        {
            List<Enc> Enc = new List<Enc>();
            if (string.IsNullOrEmpty(search))
            {
                Enc = _context.Encs.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                Enc = _context.Encs.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index2", Enc); ;
        }

        public IActionResult Searchid(string? search)
        {
            List<Enc> Enc = new List<Enc>();
            if (string.IsNullOrEmpty(search))
            {
                Enc = _context.Encs.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                Enc = _context.Encs.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index2", Enc); ;
        }
        // GET: Encs
        public async Task<IActionResult> Index(int? page)
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList().ToPagedList(page ?? 1, 25);
            var users = _context.Users.ToList();
            var saved = _context.Saved.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc.ToList(),
                appusers = users,
                SaveBooks = saved

            };
            return View(show);
            //return View(await _context.Encs.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            return View(await _context.Encs.ToListAsync());
        }
        // GET: Encs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enc = await _context.Encs
                .FirstOrDefaultAsync(m => m.id == id);
            if (enc == null)
            {
                return NotFound();
            }

            return View(enc);
        }
        // GET: Encs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,FullName,Description,Category,Store,Poster")] Enc enc, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\EncImages\\" + imgName;
                    enc.Poster = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();
                    }
                    else
                    {
                        enc.Poster = "\\EncImages\\NoUser.jpg";
                    }
                    _context.Add(enc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(enc);
            }
   
        // GET: Encs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enc = await _context.Encs.FindAsync(id);
            if (enc == null)
            {
                return NotFound();
            }
            return View(enc);
        }

        // POST: Encs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,FullName,Description,Category,Store,Poster")] Enc enc, IFormFile imageFile)
        {
            if (id != enc.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncExists(enc.id))
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
            return View(enc);
        }

        // GET: Encs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enc = await _context.Encs
                .FirstOrDefaultAsync(m => m.id == id);
            if (enc == null)
            {
                return NotFound();
            }

            return View(enc);
        }

        // POST: Encs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Enc Enc = _context.Encs.FirstOrDefault(e => e.id == id);

            if (Enc.Poster != "\\EncImages\\NoUser.jpg")
            {
                string imgPath = WebHostEnvironment.WebRootPath + Enc.Poster;

                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }
            var enc = await _context.Encs.FindAsync(id);
            _context.Encs.Remove(enc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncExists(int id)
        {
            return _context.Encs.Any(e => e.id == id);
        }
    }
}
