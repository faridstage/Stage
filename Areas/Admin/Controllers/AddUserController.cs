using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddUserController : Controller
    {
        public IActionResult User()
        {
            return View();
        }
    }
}
