using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;
        private readonly UserManager<ApplicationUser> userManager;
        public AdmissionController(cms_06GContext context, IWebHostEnvironment iWebHost , UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.iWebHost = iWebHost;
        }

        [Authorize]
        public IActionResult Index()
        {
            //var list = context.TblStudent.Include(x => x.StuPreviousExeme).Include(x => x.Status).ToList();
            //return View(list);
            return View();
        }


        public IActionResult Create(string? key)
        {
            ViewData["key"] = key;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TblStudent model)
        {
            ApplicationUser usr = await userManager.GetUserAsync(HttpContext.User);
            if(usr != null)
            {
                var UseralredyHasAdmission = context.TblStudent.Where(x => x.userId.Contains(usr.Id)).ToList();
                if (UseralredyHasAdmission.Count == 0)
                {
                    model.userId = usr.Id;
                    if (ModelState.IsValid)
                    {
                        //____________ Image _________
                        var folder = "";
                        if (model.BrowsImage != null)
                        {
                            folder = "Images/Students/";
                            folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
                            var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                            //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                            using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                            {
                                model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                            }
                        }

                        //___________ Create ___________
                        model.StuImage = folder;
                        model.StatusId = 1;
                        context.TblStudent.Add(model);
                        context.SaveChanges();
                        return RedirectToAction("PendingMessage", new { id = model.StuId });
                    }
                    else{
                        
                    }
                }
                else
                {
                    TempData["swalerror"] = "You Alredy Has Admission...";
                    TempData["swalText"] = "Check Your Admission";
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Account", new {area= "Security" });
            }
            return View(model);
        }


        //______ Alert Page _______
        public IActionResult PendingMessage(int id)
        {
            var selectedRecord = context.TblStudent.Find(id);
            return View(selectedRecord);
        }


    }

}
