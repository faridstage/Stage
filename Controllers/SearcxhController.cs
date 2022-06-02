using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stage_Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stage_Books.Controllers
{


    public class SearcxhController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearcxhController(ApplicationDbContext context)
        {
            
            _context = context;
        }
        // GET: SearcxhController
        public ActionResult Index()
        {

            return View();
           
        }
        public IActionResult Search()
        {

            return View();
       
        }
        // GET: SearcxhController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: SearcxhController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearcxhController/Create
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

        // GET: SearcxhController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearcxhController/Edit/5
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

        // GET: SearcxhController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearcxhController/Delete/5
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
