using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly cms_06GContext context;
        private readonly UserManager<ApplicationUser> identityUserManager;
        private readonly SignInManager<ApplicationUser> identityManager;
        private readonly IWebHostEnvironment iWebHost;
        public UserController(cms_06GContext context, UserManager<ApplicationUser> identityUserManager, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iWebHost)
        {
            this.identityUserManager  = identityUserManager;
            this.identityManager = identityManager;
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var userList = context.Users.ToList();
            return View(userList);
        }

        public IActionResult Create(string? key)
        {
            ViewData["key"] = key;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(signupModel signUp)
        {
            if (ModelState.IsValid)
            {
                //_____ Check Email _________ (by Default hotaa ha Validate)
                var checkUser = await identityUserManager.FindByEmailAsync(signUp.Email);
                if (checkUser == null)
                {
                    ViewBag.email = "Match";
                }
                else
                {
                    ViewBag.email = "Email Aready Exist";
                    return View();
                }

                var folder = "";
                if (signUp.iImage != null)
                {
                    folder = "Images/Users/";
                    folder += Guid.NewGuid().ToString() + "_" + signUp.iImage.FileName;
                    var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                    //model.iImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                    {
                        signUp.iImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                    }
                }

                var appUer = new ApplicationUser
                {
                    Name = signUp.Name,
                    UserName = signUp.Email,
                    Email = signUp.Email,
                    Country = signUp.Country,
                    ProfileImage = folder
                };

                var result = await identityUserManager.CreateAsync(appUer, signUp.Password);


                if (result.Succeeded)
                {
                    await identityManager.SignInAsync(appUer, isPersistent: false);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }



        public async Task<IActionResult> Edit(string name)
        {
            var user = await identityUserManager.FindByNameAsync(name);

            var appUser = new ApplicationUser
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Country = user.Country,
                PasswordHash = user.PasswordHash,
                ProfileImage = user.ProfileImage
            };
            return View(appUser);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            var updateUser = await identityUserManager.FindByNameAsync(model.UserName);

            //____________ Image _________
            var folder = "";
            if (model.iImage != null)
            {
                //______ 1st Delete Current Image _____
                
                if(model.ProfileImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.ProfileImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }
                    
                

                folder = "Images/Users/";
                folder += Guid.NewGuid().ToString() + "_" + model.iImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.iImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.iImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                updateUser.ProfileImage = folder;
            }


            updateUser.Name = model.Name;
            updateUser.Email = model.Email;
            updateUser.Country = model.Country;
            

            //_______ always unique ________ isaaa saa hum , update ,delete krtaa han
            //updateUser.UserName = model.UserName;

            var result = await identityUserManager.UpdateAsync(updateUser);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "User",new {area="Admin"});
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            //context.Users.Update(model);
            //context.SaveChanges();
            return View(model);
        }

        public IActionResult delete(string userName)
        {
            var user = context.Users.Where(x=>x.UserName == userName).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
