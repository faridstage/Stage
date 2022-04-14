using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddBookController : Controller
    {
        public IActionResult AddBook()
        {
            return View();
        }
    }
}
