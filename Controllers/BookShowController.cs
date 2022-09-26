using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Stage_Books.Models;
using Microsoft.Extensions.Logging;

namespace Stage_Books.Controllers
{
    public class BookShowController : Controller
    {
        private readonly string wwwrootdirectory =
            Path.Combine(Directory.GetCurrentDirectory(), "Storebooks");
        private readonly ILogger<BookShowController> logger;

        // public IEnumerable<Author> author { get; set; }
        private readonly ApplicationDbContext _context;

        public BookShowController(ILogger<BookShowController> logger, ApplicationDbContext context)
        {
            this.logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<string> bookfile = Directory.GetFiles(wwwrootdirectory, "*.htm")
                                             .Select(Path.GetFileName).ToList();
            return View( bookfile);
        }




        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myfile)
        {
            if (myfile != null)
            {
                var path = Path.Combine(
                    wwwrootdirectory,
                    DateTime.Now.Ticks.ToString() + Path.GetExtension(myfile.FileName));

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await myfile.CopyToAsync(stream);
                }
            }
            return RedirectToAction("Index");
        }

        // this IActionResult not use 
        public IActionResult Book_Show()
        {
            //var book = _context.Books.ToList();
            //var cat = _context.categories.ToList(); 
            //var author = _context.Authors.ToList();
            //var Enc = _context.Encs.ToList();
            //var users = _context.Users.ToList();
            //var saved = _context.Saved.ToList();
            //var love = _context.loveViewModels.ToList();
            //var profile = _context.UserProfiles.ToList();
            //var show = new Showdatamodel
            //{
            //    Books = book.ToList(),
            //    Auther = author,
            //    categories = cat,
            //    Encs = Enc,
            //    appusers = users,
            //    SaveBooks = saved,
            //    Loveviews = love,
            //    userProfiles = profile

            //};
            //return View(show);
            return View();
        }


    }
}
