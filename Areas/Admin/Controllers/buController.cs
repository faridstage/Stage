using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Areas.Admin.Controllers
{
    public class buController : Controller
    {
        // GET: buController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult back()
        {
            return View();
        }
        // GET: buController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: buController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: buController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: buController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: buController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: buController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: buController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
