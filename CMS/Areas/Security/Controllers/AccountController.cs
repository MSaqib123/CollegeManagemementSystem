using CMS.Data.ViewModel;
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


        //_________________________ default Role to Set _____________________
        private readonly RoleManager<IdentityRole> identityRole;

        public AccountController(UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb, RoleManager<IdentityRole> identityRole)
        {
            this.identityRole = identityRole;
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

                var appUser = new ApplicationUser
                {
                    Name = signUp.Name,
                    UserName = signUp.Email,
                    Email = signUp.Email,
                };
                
                var result = await identityUser.CreateAsync(appUser, signUp.Password);

                
                if (result.Succeeded)
                {
                    await identityManager.SignInAsync(appUser, isPersistent: false);

                    //________________________________________ Assign Default User Role to Login User ______________________________________
                    if (await identityRole.RoleExistsAsync("User"))   //if Exist
                    {
                        await identityUser.AddToRoleAsync(appUser, "User");
                    }
                    else  //not exist  then Create UserRole   &&    Assing to Create user
                    {
                        IdentityResult role = await identityRole.CreateAsync(new IdentityRole("User"));
                        await identityUser.AddToRoleAsync(appUser, role.ToString());
                    }
                    
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
        public IActionResult SignIn(string returnUrl)
        {
            singinModel login = new singinModel
            {
                ReturnUrl = returnUrl
            };
            return View(login); 
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(singinModel signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await identityManager.PasswordSignInAsync(signIn.Email, signIn.Password, signIn.isRemember, lockoutOnFailure:false);

                if (result.Succeeded)
                {
                    //_________ In StartUp ___________________
                    //return Redirect(signIn.ReturnUrl ?? "/");

                    //_________ After Role Added ___________________
                    var user = await identityUser.FindByNameAsync(signIn.Email);
                    var role = await identityUser.GetRolesAsync(user);
                    if (role.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "dashboard", new { area = "Admin" });
                    }
                    else
                    {
                        return Redirect(signIn.ReturnUrl ?? "/");
                    }
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



        //________________________ SignIn / SignUp ________________________
        public IActionResult SigInSignOut(string? option)
        {
            if (option == "signIn")
            {
                ViewBag.option = option;
            }
            if (option == "signUp")
            {
                ViewBag.option = option;
            }

            VMSingInSingUp vm = new VMSingInSingUp();
            vm.signIn_model = new singinModel();
            vm.signUp_model = new signupModel();
            return View(vm);
        }
        [HttpPost]
        public IActionResult SigInSignOut(VMSingInSingUp model)
        {
            if (model.signIn_model == null && model.signUp_model != null)
            {
                ////_____ Check Email _________ (by Default hotaa ha Validate)
                //var checkUser = await identityUser.FindByEmailAsync(signUp.Email);
                //if (checkUser == null)
                //{
                //    ViewBag.email = "Match";
                //}
                //else
                //{
                //    ViewBag.email = "Email Aready Exist";
                //    return View(signUp);
                //}

                //var appUser = new ApplicationUser
                //{
                //    Name = signUp.Name,
                //    UserName = signUp.Email,
                //    Email = signUp.Email,
                //};

                //var result = await identityUser.CreateAsync(appUser, signUp.Password);


                //if (result.Succeeded)
                //{
                //    await identityManager.SignInAsync(appUser, isPersistent: false);

                //    //________________________________________ Assign Default User Role to Login User ______________________________________
                //    if (await identityRole.RoleExistsAsync("User"))   //if Exist
                //    {
                //        await identityUser.AddToRoleAsync(appUser, "User");
                //    }
                //    else  //not exist  then Create UserRole   &&    Assing to Create user
                //    {
                //        IdentityResult role = await identityRole.CreateAsync(new IdentityRole("User"));
                //        await identityUser.AddToRoleAsync(appUser, role.ToString());
                //    }

                //    return RedirectToAction("Index", "Home", new { area = "" });
                //}
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
                ViewBag.bg = "SignUP";
            }
            if (model.signIn_model != null && model.signUp_model == null)
            {
                ViewBag.bg = "login";
                return RedirectToAction("Index", "Home", new { area=""});
            }
            return View();
        }


        //________________________ UpdateProfile _____________________________
        public IActionResult UpdateProfile(string url)
        {
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


        //________________________ PageNotFound_404_ _____________________________
        public IActionResult PageNotFound_404(string url)
        {
            return View();
        }
    }
}
