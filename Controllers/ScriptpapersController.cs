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

namespace Stage_Books.Controllers
{
    public class ScriptpapersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScriptpapersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Scriptpapers
        public async Task<IActionResult> Index(int? page)
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var users = _context.Users.ToList();
            var saved = _context.Saved.ToList();
            var scripts = _context.Scriptpaper.ToList().ToPagedList(page ?? 1, 25);
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc.ToList(),
                appusers = users,
                SaveBooks = saved,
                Scriptpaper = scripts.ToList()

            };
            return View(show);
            //return View(await _context.Scriptpaper.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("id,scriptname,scriptdiscription,scriptlang,scriptdiscovored,scriptdiscovoreddate,scriptdiscovoredpalce,scriptwriterby,scripttopic,scriptdate,scriptcategory,scriptcode,scriptpalcestore,scriptimage,scripturl,scriptnote")] Scriptpaper scriptpaper)
        {
            if (ModelState.IsValid)
            {
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
    }
}
