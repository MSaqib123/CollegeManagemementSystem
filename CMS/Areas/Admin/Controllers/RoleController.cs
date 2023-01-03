using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IWebHostEnvironment iweb;

        //_________________________ 1 _____________________
        private readonly cms_06GContext context;
        private readonly UserManager<ApplicationUser> identityUser;
        private readonly SignInManager<ApplicationUser> identityManager;

        //_________________________ 2 _____________________
        private readonly RoleManager<IdentityRole> identityRole;

        public RoleController(UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb, RoleManager<IdentityRole> identityRole)
        {
            this.identityRole = identityRole;
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iweb = iweb;
        }
        
        public IActionResult Index()
        {
            var list = context.Roles.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([MinLength(2), Required] string name)
        {
            //ViewBag.roleList = new SelectList(roleManager.Roles,"Name","Id");
            if (ModelState.IsValid)
            {
                IdentityResult result = await identityRole.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }
            return View();
        }


        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await roleManager.FindByIdAsync(id);
        //    await roleManager.DeleteAsync(role);
        //    TempData["danger"] = "Role Deleted Success";
        //    return RedirectToAction("Index");
        //}


        //public async Task<IActionResult> Edit(string id)
        //{
        //    IdentityRole role = await roleManager.FindByIdAsync(id);
        //    List<AppUser> members = new List<AppUser>();
        //    List<AppUser> nonMembers = new List<AppUser>();
        //    foreach (AppUser user in userManager.Users)
        //    {
        //        var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
        //        list.Add(user);
        //    }

        //    return View(new RoleEdit
        //    {
        //        Role = role,
        //        Members = members,
        //        NonMembers = nonMembers
        //    });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(RoleEdit roleEdit)
        //{
        //    IdentityResult result;

        //    //___ addIds ____
        //    foreach (string userId in roleEdit.AddIds ?? new string[] { })
        //    {
        //        AppUser user = await userManager.FindByIdAsync(userId);
        //        result = await userManager.AddToRoleAsync(user, roleEdit.RoleName);
        //    }

        //    //___ addIds ____
        //    foreach (string userId in roleEdit.DeleteIds ?? new string[] { })
        //    {
        //        AppUser user = await userManager.FindByIdAsync(userId);
        //        result = await userManager.RemoveFromRoleAsync(user, roleEdit.RoleName);
        //    }

        //    return Redirect(Request.Headers["Referer"].ToString());

        //}



    }
}
