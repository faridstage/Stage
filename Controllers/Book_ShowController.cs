using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stage_Books.Controllers
{
    public class Book_ShowController : Controller
    {
        // GET: Book_ShowController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book_Show()
        {
            return View();
        }
        // GET: Book_ShowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book_ShowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book_ShowController/Create
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

        // GET: Book_ShowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book_ShowController/Edit/5
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

        // GET: Book_ShowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book_ShowController/Delete/5
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
