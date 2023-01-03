using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public TeacherController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblFaculties.Include(x=>x.Dep).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            var list = context.TblDepartement.ToList();
            ViewBag.dep = new SelectList(list, "DepId", "Departement");
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblFaculties model)
        {
            //____________ Image _________
            var folder = "";
            if (model.BrowsImage != null)
            {
                folder = "Images/Teachers/";
                folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
            }

            model.FacImage = folder;


            //___________ Create ___________
            context.TblFaculties.Add(model);
            context.SaveChanges();
            TempData["success"] = "Teacher Added Successfuly!";
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var list = context.TblDepartement.ToList();
            ViewBag.dep = new SelectList(list, "DepId", "Departement");

            var selectedRecord = context.TblFaculties.Find(id);
            return View(selectedRecord);
        }

        [HttpPost]
        public IActionResult Edit(TblFaculties model)
        {
            var folder = "";
            if (model.BrowsImage != null)
            {
                //______ 1st Delete Current Image _____
                if (model.FacImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.FacImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }

                //______ 2nd Add new Image _______
                folder = "Images/Teachers/";
                folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));

                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }

                model.FacImage = folder;
            }


            context.TblFaculties.Update(model);
            context.SaveChanges();
            TempData["success"] = "Teacher Added Successfuly!";
            return RedirectToAction("Index");
        }



        public IActionResult delete(int id)
        {
            var Course = context.TblFaculties.Find(id);

            context.TblFaculties.Remove(Course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
