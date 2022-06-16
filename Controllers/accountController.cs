using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Stage_Books.Models;
using Stage_Books.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Stage_Books.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment WebHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IWebHostEnvironment webHostEnv)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
            WebHostEnvironment = webHostEnv;
        }
        // GET: accountController
        public ActionResult Index()
        {
           
            return View();
        }
        // get search
        public IActionResult Search(string? search)
        {
            //IEnumerable<RegisterViewModel> RegisterViewModel = new List<RegisterViewModel>();
            List<RegisterViewModel> RegisterViewModel = new List<RegisterViewModel>();
            if (string.IsNullOrEmpty(search))
            {
                RegisterViewModel = _context.users.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = search;
                RegisterViewModel = _context.users.Where(e => e.Name.Contains(search)).ToList();
            }
            return View("index_show", RegisterViewModel); 
        }
        public IActionResult Searche(string? searche)
        {
            //IEnumerable<RegisterViewModel> RegisterViewModel = new List<RegisterViewModel>();
            List<RegisterViewModel> RegisterViewModel = new List<RegisterViewModel>();
            if (string.IsNullOrEmpty(searche))
            {
                RegisterViewModel = _context.users.ToList();
            }
            else
            {
                ViewBag.CurrentSearch = searche;
                RegisterViewModel = _context.users.Where(e => e.Email.Contains(searche)).ToList();
            }
            return View("index_show", RegisterViewModel); ;
        }
        public async Task<IActionResult> index_show()
        {
            return View(await _context.users.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index(int? page)
        {
            var book = _context.Books.ToList();
            var author = _context.Authors.ToList();
            var Enc = _context.Encs.ToList();
            var users = _context.Users.ToList();
            var saved = _context.Saved.ToList();
            var show = new Showdatamodel
            {
                Books = book.ToList(),
                Auther = author,
                Encs = Enc,
                appusers = users,
                SaveBooks = saved

            };
            return View(show);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                
                var user = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    phone = model.phone,
                    gender = model.gender,
                    country = model.country,
                    city = model.Nlanguage,
                    work = model.work,
                    birth = model.birth,
                    ImageURL = model.ImageURL
                };
                if (imageFile != null)
                {
                    // Guid -> globally Unique Identifier
                    string imgExtension = Path.GetExtension(imageFile.FileName);
                    Guid imgGuid = Guid.NewGuid();
                    string imgName = imgGuid + imgExtension;
                    string imgURL = "\\UserImages\\" + imgName;
                    model.ImageURL = imgURL;

                    string imgPath = WebHostEnvironment.WebRootPath + imgURL;
                    FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                    imageFile.CopyTo(imgStream);
                    imgStream.Dispose();


                }
                else
                {
                    model.ImageURL = "\\UserImages\\NoUser.jpg";
                }
                var result = await userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login 5ra");
            }
            return View(model);
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
