using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stage_Books.Controllers
{
    public class Book_DetailsController : Controller
    {
        // GET: Book_DetailsController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book_Details()
        {
            return View();
        }
        // GET: Book_DetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book_DetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book_DetailsController/Create
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

        // GET: Book_DetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book_DetailsController/Edit/5
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

        // GET: Book_DetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book_DetailsController/Delete/5
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
