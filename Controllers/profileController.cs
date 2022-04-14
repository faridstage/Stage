using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Controllers
{
    public class profileController : Controller
    {
        // GET: profileController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult profile()
        {
            return View();
        }
        // GET: profileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: profileController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: profileController/Create
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

        // GET: profileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: profileController/Edit/5
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

        // GET: profileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: profileController/Delete/5
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
