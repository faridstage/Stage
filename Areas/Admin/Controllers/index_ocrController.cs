using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class index_ocrController : Controller
    {
        public IActionResult index_ocr()
        {
            return View();
        }
    }
}
