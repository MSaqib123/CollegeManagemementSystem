using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace CMS.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class DepartementController : Controller
    {

        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;
        public DepartementController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblDepartement.ToList();
            return View(list);
        }



        public IActionResult Create(string? key)
        {
            ViewData["key"] = key;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblDepartement model)
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

            model.depImage = folder;


            context.TblDepartement.Add(model);
            context.SaveChanges();
            TempData["success"] = "Added Successfuly!";
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id )
        {
            var selectedRecord = context.TblDepartement.Find(id);
            return View(selectedRecord);
        }
        [HttpPost]
        public IActionResult Edit(TblDepartement model)
        {
            var folder = "";
            if (model.BrowsImage != null)
            {
                //______ 1st Delete Current Image _____
                if (model.depImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.depImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }

                //______ 2nd Add new Image _______
                folder = "Images/Departement/";
                folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                model.depImage = folder;
            }
            context.TblDepartement.Update(model);
            context.SaveChanges();
            TempData["success"] = "Updated Successfuly!";
            return RedirectToAction("Index");
        }



        public IActionResult delete(int id)
        {            
            var dep = context.TblDepartement.Find(id);
            //______ 1st Delete Current Image _____
            if (dep.depImage != null)
            {
                var oldDirectory = Path.Combine(iWebHost.WebRootPath, dep.depImage);
                if (System.IO.File.Exists(oldDirectory))
                {
                    System.IO.File.Delete(oldDirectory);
                }
            }
            context.TblDepartement.Remove(dep);
            context.SaveChanges();
            TempData["error"] = "Removed Successfuly!";
            return RedirectToAction("Index");
        }

    }
}
