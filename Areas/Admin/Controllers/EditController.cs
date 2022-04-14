using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditController : Controller
    {
        public IActionResult Edit()
        {
            return View();
        }
    }
}
