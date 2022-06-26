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
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Stage_Books.Controllers
{
    public class paperssearchersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public paperssearchersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: paperssearchers
        public async Task<IActionResult> Index(int? page)
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var users = _context.Users.ToList();
            var saved = _context.Saved.ToList();
            var papers = _context.paperssearchers.ToList().ToPagedList(page ?? 1, 25);
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
                appusers = users,
                SaveBooks = saved,
                paperssearcher = papers.ToList()
            };
            return View(show);
            //return View(await _context.paperssearchers.ToListAsync());
        }

        // GET: paperssearchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperssearcher = await _context.paperssearchers
                .FirstOrDefaultAsync(m => m.id == id);
            if (paperssearcher == null)
            {
                return NotFound();
            }

            return View(paperssearcher);
        }

        // GET: paperssearchers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: paperssearchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,searchername,SerchName,topic,lang,PagesNumber,publishdate,category,image,url,note")] paperssearcher paperssearcher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paperssearcher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paperssearcher);
        }

        // GET: paperssearchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperssearcher = await _context.paperssearchers.FindAsync(id);
            if (paperssearcher == null)
            {
                return NotFound();
            }
            return View(paperssearcher);
        }

        // POST: paperssearchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,searchername,SerchName,topic,lang,PagesNumber,publishdate,category,image,url,note")] paperssearcher paperssearcher)
        {
            if (id != paperssearcher.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paperssearcher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!paperssearcherExists(paperssearcher.id))
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
            return View(paperssearcher);
        }

        // GET: paperssearchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperssearcher = await _context.paperssearchers
                .FirstOrDefaultAsync(m => m.id == id);
            if (paperssearcher == null)
            {
                return NotFound();
            }

            return View(paperssearcher);
        }

        // POST: paperssearchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paperssearcher = await _context.paperssearchers.FindAsync(id);
            _context.paperssearchers.Remove(paperssearcher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool paperssearcherExists(int id)
        {
            return _context.paperssearchers.Any(e => e.id == id);
        }
    }
}
