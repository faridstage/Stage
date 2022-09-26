using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stage_Books.Models;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using X.PagedList.Mvc.Core;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Stage_Books.Controllers
{

    public class HomeController : Controller
    {


        // public IEnumerable<Author> author { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public static int savedCount = 0;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public int SavedCount()
        {
            int i = 0;
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(id != null)
            {
                i = _context.Saved.Where(x=>x.UserId == id).Count();
            }
            else
            {
                i = 0;
            }
            return i;
        }

        public IActionResult Index(int? page)
        {
            var book = _context.Books.ToList().ToPagedList(page ?? 1, 25);
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var users = _context.Users.ToList();
            var saved = _context.Saved.ToList();
            var love = _context.loveViewModels.ToList();
            var profile = _context.UserProfiles.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
                appusers = users,
                SaveBooks = saved,
                Loveviews = love,
                userProfiles = profile

            };
            return View(show);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var lovebook = await _context.loveViewModels.FirstOrDefaultAsync(l => l.Love_count == id);
            lovebook.Love_count++;
            _context.Update(lovebook);
            _context.SaveChanges();
            return View();
        }
        public IActionResult publishercont()
        {
            return View();
        }
        public IActionResult authercont()
        {
            return View();
        }
        
         public IActionResult suggestion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchname)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Name.Contains(searchname)
                         || b.Author.Name.Contains(searchname)
                         || b.Topic.Contains(searchname)
                         || b.Category.Contains(searchname)).ToList();

            return View(result);
        }


        public ActionResult Searchbyenglish(string Searchbyenglish)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Language == "English").ToList();

            return View(result);
        }
        public ActionResult Searchbyrabic(string Searchbyrabic)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Language == "Arabic").ToList();

            return View(result);
        }

        public ActionResult Searchbygerman(string Searchbygerman)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Language == "German").ToList();

            return View(result);
        }
        public ActionResult Searchbyspanish(string Searchbyspanish)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Language == "Spanish").ToList();

            return View(result);
        }
        public ActionResult Searchbyfrench(string Searchbyfrench)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Language == "French").ToList();

            return View(result);
        }

        public ActionResult Searchbyhindi(string Searchbyhindi)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            var result = _context.Books.Where(b => b.Language == "Hindi").ToList();

            return View(result);
        }
    
                           
        public async Task<ActionResult> gotobooks()
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
            };
            return View(show);
            //return View(await _context.Books.ToListAsync());
        }
        public ActionResult gotoauthors()
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
            };
            return View(show);
        }
        public ActionResult gotocat()
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
            };
            return View(show);
        }
        public ActionResult gototopic()
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
            };
            return View(show);
        }
        public ActionResult gotoenc()
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
            };
            return View(show);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult setlang(string culture, string returnurl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            return LocalRedirect(returnurl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SaveBook(string id)
        {
            if(id != null)
            {
                ViewBag.SaveBook = await GetSaveBook(id);
            }
            
            return View();
        }

        public async Task<List<SaveBook>> GetSaveBook(string userId)
        {
            return await _context.Saved.Where(x =>x.UserId == userId).ToListAsync();
        }

        public bool GetBookName(string bookName,string id)
        {
            return _context.Saved.Where(s =>s.UserId == id).Any(x=>x.BookName == bookName);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveBook([Bind("Id,BookName,bookDesc,ImageURL")] SaveBook saveBook, string bookName, string? bookDesc, string bookImage, int bookId)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (id == null)
            {
                TempData["msg"] = "Please Login First";
                return RedirectToAction("Details", "books");
            }
            if (ModelState.IsValid)
            {
                if (!GetBookName(bookName,id))
                {
                    saveBook.BookName = bookName;
                    saveBook.bookDesc = bookDesc;
                    saveBook.ImageURL = bookImage;
                    saveBook.UserId= id;


                    _context.Add(saveBook);

                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Saved ON;");
                    await _context.SaveChangesAsync();
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Saved OFF;");
                    savedCount = SavedCount();
                }
                else
                {
                    TempData["msg"] = "The Book is alredy saved";
                }


            }
            return RedirectToAction("Book_Details","books", new { id = bookId });
        }

        //// start buy order 
        //[HttpGet]
        //public IActionResult order()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult order(OrderViewModel model)
        //{
        //    return View();
        //}

        
        public ActionResult Searchgotobooks(string searchname)
        {
            //var result = _context.Books.Include(x => x.Author).Where(b => b.Name.Contains(searchname) || b.Author.Name.Contains(searchname)).ToList();
            //*****************
            //var result = _context.Books.Where(b => b.Name.Contains(searchname)
            //             || b.Author.Name.Contains(searchname)
            //             || b.Topic.Contains(searchname)
            //             || b.Category.Contains(searchname)).ToList();

            //return View(result);
            //****************
            List<Book> Book = new List<Book>();
            if (string.IsNullOrEmpty(searchname))
            {
                Book = _context.Books.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searchname;
                Book = _context.Books.Where(e => e.Name.Contains(searchname)).ToList();
            }
            return View("gotobooks", Book);
        }
    }
}
