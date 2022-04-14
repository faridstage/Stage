using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stage_Books.Controllers
{
    public class accountController : Controller
    {
        // GET: accountController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        
        // GET: accountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: accountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: accountController/Create
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

        // GET: accountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: accountController/Edit/5
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

        // GET: accountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: accountController/Delete/5
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
