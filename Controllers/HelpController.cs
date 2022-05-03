using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
    }
}
