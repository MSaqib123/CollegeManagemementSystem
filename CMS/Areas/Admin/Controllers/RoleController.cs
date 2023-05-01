using CMS.Data;
using CMS.Data.ViewModel;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IWebHostEnvironment iweb;

        //_________________________ 1 _____________________
        private readonly cms_06GContext context;
        private readonly UserManager<ApplicationUser> identityUser;
        private readonly SignInManager<ApplicationUser> identityManager;

        //_________________________ 2 _____________________
        private readonly RoleManager<IdentityRole> identityRole;

        public RoleController(cms_06GContext context, UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb, RoleManager<IdentityRole> identityRole)
        {
            this.context = context;
            this.identityRole = identityRole;
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iweb = iweb;
        }
        
        //_______________________ Index Roles _____________________________
        public IActionResult Index()
        {
            var list = context.Roles.ToList();
            return View(list);
        }


        //_______________________ Create Roles _____________________________
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


        //_______________________ Edit Roles _____________________________
        public async Task<IActionResult> Edit(string id)
        {
            var role = await identityRole.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} can not be found";
                return RedirectToAction("Index");
            }

            var model = new VMEditRole
            {
                Id = role.Id,
                RoleName = role.Name
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VMEditRole model)
        {
            //database role Record
            var role = await identityRole.FindByIdAsync(model.Id);
            if(role != null)
            {
                role.Name = model.RoleName; //update database roleName  from model rolename
                var result = await identityRole.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError("", error.Description);
                }
            }
            return View();
        }





        //_______________________ Delete Roles _____________________________
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await identityRole.FindByIdAsync(id);
            await identityRole.DeleteAsync(role);
            TempData["danger"] = "Role Deleted Success";
            return RedirectToAction("Index");
        }


        //_______________________ Manage Roles _____________________________
        public async Task<IActionResult> RoleAssign(string id)
        {
            IdentityRole role = await identityRole.FindByIdAsync(id);

            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();

            foreach (ApplicationUser user in identityUser.Users)
            {
                //If)  check kraa gaa ---> user kaa --> against  ---> koi  Role haaa  --> to Wo member  laa aya
                //else)    NonMember   select kraa gaa
                var list = await identityUser.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                //or List me Add kr da gaa
                list.Add(user);
            }


            return View(new VMRoleAssign
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoleAssign(VMRoleAssign roleEdit)
        {
            IdentityResult result;

            //___ Add Roles for select User ____
            foreach (string userId in roleEdit.AddIds ?? new string[] { })
            {
                ApplicationUser user = await identityUser.FindByIdAsync(userId);
                result = await identityUser.AddToRoleAsync(user, roleEdit.RoleName);
            }

            //___ Remove Roles for select User ____
            foreach (string userId in roleEdit.DeleteIds ?? new string[] { })
            {
                ApplicationUser user = await identityUser.FindByIdAsync(userId);
                result = await identityUser.RemoveFromRoleAsync(user, roleEdit.RoleName);
            }

            return Redirect(Request.Headers["Referer"].ToString());

        }



        //_______________________ Add Default Role to Registore user _________________________________

        //if (await roleManager.RoleExistsAsync(UserRoles.User))
        //{
        // await userManager.AddToRoleAsync(user, UserRoles.User);
        //}




        //_______________________ Move to Dashboard -IF-  login is Admin _________________________________
        //admin ager login ho to  direct  ---->  Dashbaord par gy

        //var user = await identityUser.FindByNameAsync(signIn.Email);
        //var role = await identityUser.GetRolesAsync(user);
        //if (role.Contains("Admin"))
        //{
        //}

    }
}
