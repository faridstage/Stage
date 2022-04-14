using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Controllers
{
    public class booksController : Controller
    {
        // GET: booksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: booksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: booksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: booksController/Create
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

        // GET: booksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: booksController/Edit/5
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

        // GET: booksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: booksController/Delete/5
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
