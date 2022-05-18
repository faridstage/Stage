using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Controllers
{
    public class BookShowController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Book_Show()
        {
            return View();
        }
    }
}
