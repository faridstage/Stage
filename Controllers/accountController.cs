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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.Office.Interop.Word;
using System.ComponentModel.DataAnnotations;

namespace Stage_Books.Controllers
{
    public class AccountController : Controller
    {
        public static bool IsProfileExists { get; set; }

        public static long UID { get; set; }


        private readonly ApplicationDbContext _context;
        IWebHostEnvironment WebHostEnvironment;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, IWebHostEnvironment webHostEnv)
        {
            this.roleManager = roleManager;
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
                    UserName = new MailAddress(model.Email).User,
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

                int userCount = _context.Users.Count();

                var result = await userManager.CreateAsync(user, model.Password);

                string userId = user.Id;
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    if (userCount <= 0)
                    {
                        AppRole appRole = new AppRole();
                        appRole.Id = Guid.NewGuid().ToString();
                        appRole.RoleName = "Admin";
                        await _context.AddAsync(appRole);
                        await _context.SaveChangesAsync();
                        string roleId = appRole.Id;

                        AppUserRole appUserRole = new AppUserRole();
                        appUserRole.Id = Guid.NewGuid().ToString();
                        appUserRole.RoleId = roleId;
                        appUserRole.UserId = userId;
                        await _context.AddAsync(appUserRole);
                        await _context.SaveChangesAsync();

                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = appRole.RoleName
                        };
                        IdentityResult result1 = await roleManager.CreateAsync(identityRole);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("ListRoles", "Administration");
                        }

                        foreach (IdentityError error in result1.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }


                    }
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
            var username = new EmailAddressAttribute().IsValid(model.Email) ? userManager.FindByEmailAsync(model.Email).Result.UserName : model.Email;
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
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

        public async Task<IActionResult> UserControl()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            if (UserIdProfileExists(id))
            {
                IsProfileExists = true;
            }
            else
            {
                IsProfileExists = false;
            }

            long profileId = GetUserProfileId(id);

            if (profileId > 0)
            {
                UID = profileId;
            }
            else
            {
                UID = 0;
            }

            return View(user);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }


        // POST: UserProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile([Bind("Id,Name,UserId,UserImage")] UserProfile userProfile, IFormFile img)
        {
            ViewBag.msg = string.Empty;
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (id == null)
            {
                return NotFound();
            }
            string NewFileName = string.Empty;

            if (img != null && img.Length > 0)
            {
                string fn = img.FileName;
                if (IsImageValidate(fn))
                {
                    string ext = Path.GetExtension(fn);
                    NewFileName = Guid.NewGuid().ToString() + ext;
                    string fileName = Path.Combine(WebHostEnvironment.WebRootPath + "/UserImages", NewFileName);
                    await img.CopyToAsync(new FileStream(fileName, FileMode.Create));
                }
                else
                {
                    ViewBag.msg = "Please Choose Image with ext is .png or jpeg or jpg";
                    return View();
                }
            }

            if (string.IsNullOrEmpty(userProfile.UserId) && string.IsNullOrEmpty(userProfile.Name) && string.IsNullOrEmpty(userProfile.UserImage))
            {
                ViewBag.msg = "you did not choose any data";
                return View();
            }
            userProfile.UserId = id;
            userProfile.UserImage = NewFileName;

            _context.Add(userProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserControl));
        }

        private bool IsImageValidate(string filename)
        {
            string ext = Path.GetExtension(filename);
            if (ext.Contains(".png"))
                return true;
            if (ext.Contains(".jpg"))
                return true;
            if (ext.Contains(".jpeg"))
                return true;
            return false;
        }

        // GET: UserProfiles/Edit/5
        public async Task<IActionResult> EditProfile(long? id)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound();
            }
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.UserProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            return View(userProfile);
        }

        // POST: UserProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(long id, [Bind("Id,Name,UserId,UserImage")] UserProfile userProfile, IFormFile img)
        {

            if (id != userProfile.Id)
            {
                return NotFound();
            }

            ViewBag.msg = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    string url = string.Empty;
                    url = userProfile.UserImage;
                    string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        string NewFileName = string.Empty;

                        if (img != null && img.Length > 0)
                        {
                            string fn = img.FileName;
                            if (IsImageValidate(fn))
                            {
                                string ext = Path.GetExtension(fn);
                                NewFileName = Guid.NewGuid().ToString() + ext;
                                string fileName = Path.Combine(WebHostEnvironment.WebRootPath + "/UserImages", NewFileName);
                                await img.CopyToAsync(new FileStream(fileName, FileMode.Create));
                            }
                            else
                            {
                                ViewBag.msg = "Please Choose Image with ext is .png or jpeg or jpg";
                                return View();
                            }
                        }
                        else
                        {
                            NewFileName = url;
                        }
                        userProfile.UserImage = NewFileName;
                        userProfile.UserId = userId;
                        _context.Update(userProfile);
                        await _context.SaveChangesAsync();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(UserControl));
            }

            return View(userProfile);
        }

        private bool UserProfileExists(long id)
        {
            return _context.UserProfiles.Any(e => e.Id == id);
        }

        private bool UserIdProfileExists(string userId)
        {
            return _context.UserProfiles.Any(e => e.UserId == userId);
        }
        private long GetUserProfileId(string userId)
        {
            try
            {
                long id = _context.UserProfiles.Where(e => e.UserId == userId).Select(e => e.Id).FirstOrDefault();
                return id;
            }
            catch
            {

            }
            return 0;
        }

        private string GetUserPassword(string userId)
        {
            try
            {
                return _context.Users.Where(e => e.Id == userId).Select(e => e.PasswordHash).FirstOrDefault();
            }
            catch
            {

            }
            return string.Empty;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult VerifyPassword(string pass)
        {
            if (pass == null)
            {
                return RedirectToAction(nameof(UserControl));
            }
            string password = pass;
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(id))
            {
                if (password == GetUserPassword(id))
                {
                    return RedirectToAction(nameof(ChangePassword));
                }
                else
                {
                    ViewBag.msg = "Password is Not right";
                }
            }


            return RedirectToAction(nameof(UserControl));
        }
        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        public async Task<ActionResult> ChangePassword(string pass, string passConfirm)
        {
            if (pass == null || passConfirm == null)
            {
                return RedirectToAction(nameof(UserControl));
            }
            string password = pass;
            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(id))
            {
                if (pass == passConfirm)
                {
                    var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
                    if (user != null)
                    {
                        user.PasswordHash = password;
                        _context.Attach(user);
                        _context.Entry(user).Property(x => x.PasswordHash).IsModified = true;
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(UserControl));
                    }
                }
                else
                {
                    ViewBag.msg = "Password does not match";
                }
            }
            else
            {
                return View("Index", "Home");
            }


            return View();
        }

    }
}
