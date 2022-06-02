using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Stage_Books.Controllers
{
    public class BookShowController : Controller
    {
        private readonly string wwwrootdirectory =
            Path.Combine(Directory.GetCurrentDirectory(), "Storebooks");

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
            return View();
        }


    }
}
