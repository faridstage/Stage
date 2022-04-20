using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Stage_Books.Models;


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
        [HttpPost]
        //public IActionResult Sendemail(SendEmail se)
        //{
        //    string to = se.to;
        //    string name = se.name;
        //    string title = se.title;
        //    string msg = se.msg;
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(to);
        //    mail.Subject = title;
        //    mail.Body = msg;
        //    mail.From = new MailAddress("stage.books.2022@gmail.com");
        //    mail.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.Port = 587;
        //    smtp.UseDefaultCredentials = false;  
        //    smtp.EnableSsl = true;
        //    smtp.Credentials = new NetworkCredential("stage.books.2022@gmail.com", "stage82467913Aa");
        //    smtp.Send(mail);
        //    ViewBag.Message = "Sending Is Seccussefuly To "+"Stage";
        //    //smtp.Send("stage.books.2022@gmail.com", "amir.edward.freelancer@gmail.com", title,body);
        //    return View();
        //}
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
