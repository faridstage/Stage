using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stage_Books.Models;
using Stage_Books.Models.Contact;

namespace Stage_Books.Controllers
{
    public class ContactmsgsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactmsgsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Books/Search/5
        public IActionResult Search(string? search)
        {
            List<Contactmsg> Contactmsg = new List<Contactmsg>();
            if (string.IsNullOrEmpty(search))
            {
                Contactmsg = _context.Contactmsgs.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                Contactmsg = _context.Contactmsgs.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index", Contactmsg); ;
        }
        // GET: Contactmsgs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactmsgs.ToListAsync());
        }

        // GET: Contactmsgs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactmsg = await _context.Contactmsgs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactmsg == null)
            {
                return NotFound();
            }

            return View(contactmsg);
        }

        // GET: Contactmsgs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactmsgs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,mail,title,body")] Contactmsg contactmsg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactmsg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(contactmsg);
        }

        // GET: Contactmsgs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactmsg = await _context.Contactmsgs.FindAsync(id);
            if (contactmsg == null)
            {
                return NotFound();
            }
            return View(contactmsg);
        }

        // POST: Contactmsgs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,mail,title,body")] Contactmsg contactmsg)
        {
            if (id != contactmsg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactmsg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactmsgExists(contactmsg.Id))
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
            return View(contactmsg);
        }

        // GET: Contactmsgs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactmsg = await _context.Contactmsgs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactmsg == null)
            {
                return NotFound();
            }

            return View(contactmsg);
        }

        // POST: Contactmsgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactmsg = await _context.Contactmsgs.FindAsync(id);
            _context.Contactmsgs.Remove(contactmsg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactmsgExists(int id)
        {
            return _context.Contactmsgs.Any(e => e.Id == id);
        }

        public ActionResult Searchpaperre(string searchname)
        {
            List<Contactmsg> Book = new List<Contactmsg>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.Contactmsgs.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.Contactmsgs.Where(e => e.Name.Contains(searchname)).ToList();
            }
            return View("Index", Book);
        }
    }
}
