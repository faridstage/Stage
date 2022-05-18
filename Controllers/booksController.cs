﻿using System;
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
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment WebHostEnvironment;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment webHostEnv)
        {
            _context = context;
            WebHostEnvironment = webHostEnv;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // index_show to show all books in tabel
        public async Task<IActionResult> index_show()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Book book = _context.Books.Include(e => e.Author).FirstOrDefault(e => e.ID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        // GET: Books/Search/5
        public IActionResult Search(string btnsearch)
        {
            //Book book = _context.Books.Include(e => e.Author).FirstOrDefault(e => e.Name == btnsearch);
            Book book = _context.Books.Where(e => e.Name.StartsWith(btnsearch)).Include(e => e.Author).FirstOrDefault(e => e.Name == btnsearch);

            if (book == null)
            {
                return NotFound();
            }

            //return View("index_show", book);
            return View("index_show",book);
        }
        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.AllAuthors = _context.Authors.ToList();
            return View("Create");
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Pages,Category,Language,Topic,Publisher,PubDate,Desc,Rights,AuthorID")] Book book, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\BookImages\\" + imgName;
                    book.ImageURL = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    book.ImageURL = "\\BookImages\\NoImage.jpeg";
                }


                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.AllAuthors = _context.Authors.ToList();
                return View("Create",book);
            }
            
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {

            Book book = _context.Books.FirstOrDefault(e => e.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.AllAuthors = _context.Authors.ToList();
                return View("Edit", book);
            }
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Pages,Category,Language,Topic,Publisher,PubDate,Desc,Rights,AuthorID,ImageURL")] Book book, IFormFile imageFile)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                if (imageFile != null)
                {
                    if (book.ImageURL != "\\BookImages\\NoImage.jpeg")
                    {
                        string OldimgPath = WebHostEnvironment.WebRootPath + book.ImageURL;

                        if (System.IO.File.Exists(OldimgPath))
                        {
                            System.IO.File.Delete(OldimgPath);
                        }
                    }
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\BookImages\\" + imgName;
                    book.ImageURL = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                _context.Books.Update(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.AllAuthors = _context.Authors.ToList();
                return View(book);
            }



        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            Book book = _context.Books.FirstOrDefault(e => e.ID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = _context.Books.FirstOrDefault(e => e.ID == id);

            if (book.ImageURL != "\\BookImages\\NoImage.jpeg")
            {
                string imgPath = WebHostEnvironment.WebRootPath + book.ImageURL;

                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }
            }
            _context.Books.Remove(book);
            _context.SaveChanges();



            return RedirectToAction("Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }
    }
}
