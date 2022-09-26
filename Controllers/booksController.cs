using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;

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

        // GET: Books/Details/5
        public async Task<IActionResult> Book_Details(int? id , string cat)
        {

            Book book = _context.Books.Include(e => e.Author).FirstOrDefault(e => e.ID == id);
            //ViewBag.catstr = _context.Books.Where(z => z.ID == b.Select(p => p.CategoryId).FirstOrDefault())
            //               .Select(p => p.Name);
            //ViewBag.catstr = _context.Books.Where(b => b.Category == "علوم");
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        public async Task<IActionResult> Book_Show(int? id)
        {
            Book book = _context.Books.Include(e => e.Author).FirstOrDefault(e => e.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public PartialViewResult getsamebooks()
        {
            List<Book> books = _context.Books.ToList();
            return PartialView("bookslinks" ,books);
        }

        // GET: Books/Search/5
        public IActionResult Search(string? search)
        {
            List<Book> Book = new List<Book>();
            if (string.IsNullOrEmpty(search))
            {
                Book = _context.Books.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                Book = _context.Books.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index_show", Book);
        }

        public IActionResult Searchhome(string? searchhome)
        {
            List<Book> Book = new List<Book>();
            if (string.IsNullOrEmpty(searchhome))
            {
                Book = _context.Books.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchhome;
                Book = _context.Books.Where(e => e.Name.Contains(searchhome)).ToList();
            }
            return View("Book_Details", Book); ;
        }
        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.AllCat = _context.categories.ToList();
            ViewBag.AllAuthors = _context.Authors.ToList();
            return View("Create");
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Pages,Category,Language,Topic,Publisher,PubDate,Desc,Rights,AuthorID,CategoryID,UploadDate")] Book book, IFormFile imageFile,IFormFile bookFile,IFormFile bookIndex,IFormFile bookIntro)
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

                if (bookFile != null)
                {
                    // Guid -> globally Unique Identifier
                    string bookExtension = Path.GetExtension(bookFile.FileName);
                    Guid bookGuid = Guid.NewGuid();
                    string bookName = bookGuid + bookExtension;
                    string bookURL = "\\BookFiles\\" + bookName;
                    book.BookURLS = bookURL;

                    string bookPath = WebHostEnvironment.WebRootPath + bookURL;
                    FileStream bookStream = new FileStream(bookPath, FileMode.Create);
                    bookFile.CopyTo(bookStream);
                    bookStream.Dispose();


                }
                if (bookIndex != null)
                {
                    // Guid -> globally Unique Identifier
                    string bookIndexExtension = Path.GetExtension(bookIndex.FileName);
                    Guid bookIndexGuid = Guid.NewGuid();
                    string bookIndexName = bookIndexGuid + bookIndexExtension;
                    string bookIndexURL = "\\BookIndex\\" + bookIndexName;
                    book.BookIndex= bookIndexURL;

                    string bookIndexPath = WebHostEnvironment.WebRootPath + bookIndexURL;
                    FileStream bookIndexStream = new FileStream(bookIndexPath, FileMode.Create);
                    bookIndex.CopyTo(bookIndexStream);
                    bookIndexStream.Dispose();
                }
                if (bookIntro != null)
                {
                    // Guid -> globally Unique Identifier
                    string bookIntroExtension = Path.GetExtension(bookIntro.FileName);
                    Guid bookIntroGuid = Guid.NewGuid();
                    string bookIntroName = bookIntroGuid + bookIntroExtension;
                    string bookIntroURL = "\\BookIntro\\" + bookIntroName;
                    book.BookIntro = bookIntroURL;

                    string bookIntroPath = WebHostEnvironment.WebRootPath + bookIntroURL;
                    FileStream bookIntroStream = new FileStream(bookIntroPath, FileMode.Create);
                    bookIntro.CopyTo(bookIntroStream);
                    bookIntroStream.Dispose();


                }


                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.AllCat = _context.categories.ToList();
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Pages,Category,Language,Topic,Publisher,PubDate,Desc,Rights,AuthorID,ImageURL,UploadDate,BookURLS,BookIntro,BookIndex")] Book book, IFormFile imageFile, IFormFile bookFile, IFormFile bookIndex, IFormFile bookIntro)
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
                if (bookFile != null)
                {
                    string OldimgPath = WebHostEnvironment.WebRootPath + book.BookURLS;

                    if (System.IO.File.Exists(OldimgPath))
                    {
                        System.IO.File.Delete(OldimgPath);
                    }

                    // Guid -> globally Unique Identifier
                    string bookExtension = Path.GetExtension(bookFile.FileName);
                    Guid bookGuid = Guid.NewGuid();
                    string bookName = bookGuid + bookExtension;
                    string bookURL = "\\BookFiles\\" + bookName;
                    book.BookURLS = bookURL;

                    string bookPath = WebHostEnvironment.WebRootPath + bookURL;
                    FileStream bookStream = new FileStream(bookPath, FileMode.Create);
                    bookFile.CopyTo(bookStream);
                    bookStream.Dispose();


                }

                if (bookIndex != null)
                {
                    string OldimgPath = WebHostEnvironment.WebRootPath + book.BookIndex;

                    if (System.IO.File.Exists(OldimgPath))
                    {
                        System.IO.File.Delete(OldimgPath);
                    }

                    // Guid -> globally Unique Identifier
                    string bookIndexExtension = Path.GetExtension(bookIndex.FileName);
                    Guid bookIndexGuid = Guid.NewGuid();
                    string bookIndexName = bookIndexGuid + bookIndexExtension;
                    string bookIndexURL = "\\BookIndex\\" + bookIndexName;
                    book.BookIndex = bookIndexURL;

                    string bookIndexPath = WebHostEnvironment.WebRootPath + bookIndexURL;
                    FileStream bookIndexStream = new FileStream(bookIndexPath, FileMode.Create);
                    bookIndex.CopyTo(bookIndexStream);
                    bookIndexStream.Dispose();


                }

                if (bookIntro != null)
                {
                    string OldimgPath = WebHostEnvironment.WebRootPath + book.BookIntro;

                    if (System.IO.File.Exists(OldimgPath))
                    {
                        System.IO.File.Delete(OldimgPath);
                    }

                    // Guid -> globally Unique Identifier
                    string bookIntroExtension = Path.GetExtension(bookIntro.FileName);
                    Guid bookIntroGuid = Guid.NewGuid();
                    string bookIntroName = bookIntroGuid + bookIntroExtension;
                    string bookIntroURL = "\\BookIntro\\" + bookIntroName;
                    book.BookIntro = bookIntroURL;

                    string bookIntroPath = WebHostEnvironment.WebRootPath + bookIntroURL;
                    FileStream bookIntroStream = new FileStream(bookIntroPath, FileMode.Create);
                    bookIntro.CopyTo(bookIntroStream);
                    bookIntroStream.Dispose();
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
            string bookFilePath = WebHostEnvironment.WebRootPath + book.BookURLS;

            if (System.IO.File.Exists(bookFilePath))
            {
                System.IO.File.Delete(bookFilePath);
            }
            string bookIndexPath = WebHostEnvironment.WebRootPath + book.BookIndex;

            if (System.IO.File.Exists(bookIndexPath))
            {
                System.IO.File.Delete(bookIndexPath);
            }
            string bookIntroPath = WebHostEnvironment.WebRootPath + book.BookIntro;

            if (System.IO.File.Exists(bookIntroPath))
            {
                System.IO.File.Delete(bookIntroPath);
            }
            _context.Books.Remove(book);
            _context.SaveChanges();



            return RedirectToAction("Index");
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.ID == id);
        }


        [HttpPost]
        public ActionResult SearchIn(string searchname)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Name.Contains(searchname)
                         || b.Author.Name.Contains(searchname)
                         || b.Topic.Contains(searchname)
                         || b.Category.Contains(searchname)).ToList();

            return View(result);
        }

    }
}
