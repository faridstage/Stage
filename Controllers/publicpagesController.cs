using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Controllers
{
    public class publicpagesController : Controller
    {
        // GET: publicpagesController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult policy()
        {
            return View();
        }
        public ActionResult service()
        {
            return View();
        }
        public ActionResult about_stage()
        {
            return View();
        }

        // GET: publicpagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: publicpagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: publicpagesController/Create
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

        // GET: publicpagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: publicpagesController/Edit/5
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

        // GET: publicpagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: publicpagesController/Delete/5
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
