using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment iweb;
        private readonly UserManager<ApplicationUser> identityUser;
        private readonly SignInManager<ApplicationUser> identityManager;

        public AccountController(UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb)
        {
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iweb = iweb;
        }


        //________________________ SignUP __________________________
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(signupModel signUp)
        {
            if (ModelState.IsValid)
            {
                //_____ Check Email _________ (by Default hotaa ha Validate)
                var checkUser = await identityUser.FindByEmailAsync(signUp.Email);
                if (checkUser == null)
                {
                    ViewBag.email = "Match";
                }
                else
                {
                    ViewBag.email = "Email Aready Exist";
                    return View(signUp);
                }

                var appUer = new ApplicationUser
                {
                    Name = signUp.Name,
                    UserName = signUp.Email,
                    Email = signUp.Email,
                };
                
                var result = await identityUser.CreateAsync(appUer, signUp.Password);

                
                if (result.Succeeded)
                {
                    await identityManager.SignInAsync(appUer, isPersistent: false);
                    return RedirectToAction("Index", "Home", new {area=""});
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }


        //________________________ SignIn _____________________________
        public IActionResult SignIn(string url)
        {
            //if ( = ulr)
            //{

            //}
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(singinModel signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await identityManager.PasswordSignInAsync(signIn.Email, signIn.Password, signIn.isRemember, lockoutOnFailure:false);

                if (result.Succeeded)
                {
                    //if(User.IsInRole("Admin") != null)
                    //{
                    //    return RedirectToAction("Index","Home");
                    //}
                    //else
                    return RedirectToAction("Index","Home", new { id = "", Area = "" });
                    //return Redirect(signIn.ReturnUrl ?? "/");

                    //}
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }



        //________________________ LogOut ________________________
        public async Task<IActionResult> Logout()
        {
            await identityManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {area=""});
        }



        //________________________ UpdateProfile _____________________________
        public IActionResult UpdateProfile(string url)
        {
            //if ( = ulr)
            //{

            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(singinModel signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await identityManager.PasswordSignInAsync(signIn.Email, signIn.Password, signIn.isRemember, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }

    }
}
