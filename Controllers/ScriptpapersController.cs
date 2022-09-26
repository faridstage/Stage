using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;
using X.PagedList.Mvc.Core;
using X.PagedList;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Stage_Books.Controllers
{
    public class ScriptpapersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ScriptpapersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Scriptpapers
        public async Task<IActionResult> Index(int? page)
        {
            //var book = _context.Books.ToList();
            //var author = _context.Authors.ToList();
            //var Enc = _context.Encs.ToList();
            //var users = _context.Users.ToList();
            //var saved = _context.Saved.ToList();
            //var scripts = _context.Scriptpaper.ToList().ToPagedList(page ?? 1, 25);
            //var show = new Showdatamodel
            //{
            //    Books = book.ToList(),
            //    Auther = author,
            //    Encs = Enc.ToList(),
            //    appusers = users,
            //    SaveBooks = saved,
            //    Scriptpaper = scripts.ToList()

            //};
            //return View(show);
            return View(await _context.Scriptpaper.ToListAsync());
        }
        public async Task<IActionResult> Indexd()
        {
            return View(await _context.Scriptpaper.ToListAsync());
        }
        // GET: Scriptpapers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scriptpaper = await _context.Scriptpaper
                .FirstOrDefaultAsync(m => m.id == id);
            if (scriptpaper == null)
            {
                return NotFound();
            }

            return View(scriptpaper);
        }

        // GET: Scriptpapers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scriptpapers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,scriptname,scriptdiscription,scriptlang,scriptdiscovored,scriptdiscovoreddate,scriptdiscovoredpalce,scriptwriterby,scripttopic,scriptdate,scriptcategory,scriptcode,scriptpalcestore,scriptimage,scripturl,scriptnote")] Scriptpaper scriptpaper , IFormFile manufile , IFormFile manuimg)
        {
            if (ModelState.IsValid)
            {
                if (manuimg != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(manuimg.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\manuimg\\" + imgName;
                    scriptpaper.scriptimage = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    manuimg.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    scriptpaper.scriptimage = "\\manuimg\\NoImage.jpeg";
                }
                if (manufile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(manufile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\manufile\\" + imgName;
                    scriptpaper.scripturl = imgURL;

                    string imgPath = webHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    manufile.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    scriptpaper.scripturl = "\\manufile\\NoImage.jpeg";
                }
                _context.Add(scriptpaper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scriptpaper);
        }

        // GET: Scriptpapers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scriptpaper = await _context.Scriptpaper.FindAsync(id);
            if (scriptpaper == null)
            {
                return NotFound();
            }
            return View(scriptpaper);
        }

        // POST: Scriptpapers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,scriptname,scriptdiscription,scriptlang,scriptdiscovored,scriptdiscovoreddate,scriptdiscovoredpalce,scriptwriterby,scripttopic,scriptdate,scriptcategory,scriptcode,scriptpalcestore,scriptimage,scripturl,scriptnote")] Scriptpaper scriptpaper)
        {
            if (id != scriptpaper.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scriptpaper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScriptpaperExists(scriptpaper.id))
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
            return View(scriptpaper);
        }

        // GET: Scriptpapers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scriptpaper = await _context.Scriptpaper
                .FirstOrDefaultAsync(m => m.id == id);
            if (scriptpaper == null)
            {
                return NotFound();
            }

            return View(scriptpaper);
        }

        // POST: Scriptpapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scriptpaper = await _context.Scriptpaper.FindAsync(id);
            _context.Scriptpaper.Remove(scriptpaper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScriptpaperExists(int id)
        {
            return _context.Scriptpaper.Any(e => e.id == id);
        }

        public ActionResult Searchpaperre(string searchname)
        {
            List<Scriptpaper> Book = new List<Scriptpaper>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.Scriptpaper.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.Scriptpaper.Where(e => e.scriptname.Contains(searchname)
                        || e.scriptpalcestore.Contains(searchname)
                        || e.scriptcategory.Contains(searchname)).ToList();
            }
            return View("Index", Book);
        }
    }
}
