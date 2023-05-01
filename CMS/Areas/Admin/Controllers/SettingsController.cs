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
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {

        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public SettingsController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }


        #region Slider
        public IActionResult Slider()
        {
            var list = context.TblSlider.ToList();
            return View(list);
        }

        public IActionResult SliderCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SliderCreate(TblSlider model)
        {
            //____________ Image _________
            var folder = "";
            if (model.BrowsImage != null)
            {
                folder = "Images/Slider/";
                folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
            }

            model.sliderImage = folder;

            context.TblSlider.Add(model);
            context.SaveChanges();
            return RedirectToAction("Slider");
        }



        public IActionResult SliderEdit(int id)
        {
            var selectedRecord = context.TblSlider.Find(id);
            return View(selectedRecord);
        }
        [HttpPost]
        public IActionResult SliderEdit(TblSlider model)
        {
            var folder = "";
            if (model.BrowsImage != null)
            {
                //______ 1st Delete Current Image _____
                if (model.sliderImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.sliderImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }

                //______ 2nd Add new Image _______
                folder = "Images/Slider/";
                folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                model.sliderImage = folder;
            }
            context.TblSlider.Update(model);
            context.SaveChanges();
            return RedirectToAction("Slider");
        }


        
        public IActionResult Sliderdelete(int id)
        {
            var slider = context.TblSlider.Find(id);

            //______ 1st Delete Current Image _____
            if (slider.sliderImage != null)
            {
                var oldDirectory = Path.Combine(iWebHost.WebRootPath, slider.sliderImage);
                if (System.IO.File.Exists(oldDirectory))
                {
                    System.IO.File.Delete(oldDirectory);
                }
            }

            context.TblSlider.Remove(slider);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion




    }
}
