using CMS.Data.ViewModel;
using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FacilitesController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public FacilitesController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }


        #region SingleImage_Facility
        //public IActionResult Index()
        //{
        //    var list = context.TblFacilities.Include(x=>x.Dep).ToList();
        //    return View(list);
        //}

        //public IActionResult Create()
        //{
        //    var list = context.TblDepartement.ToList();
        //    ViewBag.dep = new SelectList(list, "DepId", "Departement");
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(TblFacilities model)
        //{
        //    //____________ Image _________
        //    var folder = "";
        //    if (model.BrowsImage != null)
        //    {
        //        folder = "Images/Facilites/";
        //        folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
        //        var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
        //        //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
        //        using (var fileMode = new FileStream(serverFolder, FileMode.Create))
        //        {
        //            model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
        //        }
        //    }
        //    model.ImageFacility = folder;


        //    //___________ Create ___________
        //    context.TblFacilities.Add(model);
        //    context.SaveChanges();
        //    TempData["success"] = "Faciality Added Successfuly!";
        //    return RedirectToAction("Index");
        //}



        //public IActionResult Edit(int id)
        //{
        //    var list = context.TblDepartement.ToList();
        //    ViewBag.dep = new SelectList(list, "DepId", "Departement");


        //    var selectedRecord = context.TblFacilities.Find(id);
        //    return View(selectedRecord);
        //}
        //[HttpPost]
        //public IActionResult Edit(TblFacilities model)
        //{
        //    var list = context.TblDepartement.ToList();
        //    ViewBag.dep = new SelectList(list, "DepId", "Departement");

        //    //____________ Image _________
        //    var folder = "";
        //    if (model.BrowsImage != null)
        //    {
        //        //______ 1st Delete Current Image _____
        //        if (model.ImageFacility  != null)
        //        {
        //            var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.ImageFacility);
        //            if (System.IO.File.Exists(oldDirectory))
        //            {
        //                System.IO.File.Delete(oldDirectory);
        //            }
        //        }


        //        //______ 2nd Add new Image _______
        //        folder = "Images/Facilites/";
        //        folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
        //        var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
        //        //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));

        //        using (var fileMode = new FileStream(serverFolder, FileMode.Create))
        //        {
        //            model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
        //        }

        //        model.ImageFacility = folder;
        //    }


        //    context.TblFacilities.Update(model);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        #endregion


        #region MultipleImage_Facility
        public IActionResult Index()
        {
            //var list = context.TblFacilities.Include(x => x.Dep).ToList();
            VM_Facilities_images vm = new VM_Facilities_images();
            vm.TblFacility = new TblFacilities();
            vm.TblFacilityImages = new TblFacilityImages();
            vm.TblFacility_List = context.TblFacilities.Include(x=>x.Dep).ToList();
            vm.TblFacilityImages_List = context.TblFacilityImages.Include(x=>x.TblFacility).ToList();
            return View(vm);
        }


        public IActionResult Create()
        {
            var list = context.TblDepartement.ToList();
            ViewBag.dep = new SelectList(list, "DepId", "Departement");
            return View();
        }
        [HttpPost]
        public IActionResult Create(VM_Facilities_images model)
        {
            //____________ 1. Single_Main_Image _________
            var folder = "";
            if (model.TblFacility.BrowsImage != null)
            {
                folder = "Images/Facilites/";
                folder += Guid.NewGuid().ToString() + "_" + model.TblFacility.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.TblFacility.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
            }
            model.TblFacility.ImageFacility = folder;

            //____________ 2. Multiple Image _________
            if(model.Images != null)
            {
                foreach (var item in model.Images)
                {
                    string fileName = UploadFile(item); //file Image 1 by 1
                    var facilityMultipleImage = new TblFacilityImages
                    {
                        ImageUrl = fileName,
                        TblFacility = model.TblFacility, //facility ka Saraa Record
                        FId = model.TblFacility.FId
                    };
                    context.TblFacilityImages.Add(facilityMultipleImage); //file Image 1 by 1
                }
            }
            

            context.TblFacilities.Add(model.TblFacility);
            context.SaveChanges();
            TempData["success"] = "Faciality Added Successfuly!";
            return RedirectToAction("Index");
        }

        public string UploadFile(IFormFile file) 
        {
            var ImageFolder = "";
            if (file != null)
            {
                ImageFolder = "Images/Facilites/Multi/";
                ImageFolder += Guid.NewGuid().ToString() + "_" + file.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, ImageFolder);
                using (var xfileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    file.CopyTo(xfileMode);
                }
            }
            return ImageFolder;
        }



        public IActionResult Edit(int id)
        {
            var list = context.TblDepartement.ToList();
            ViewBag.dep = new SelectList(list, "DepId", "Departement");

            //var selectedRecord = context.TblFacilities.Find(id);
            //return View(selectedRecord);

            VM_Facilities_images vm = new VM_Facilities_images();
            vm.TblFacility =  context.TblFacilities.Include(x=>x.TblFacilityImg).Where(x=>x.FId == id).FirstOrDefault();//new TblFacilities();
            vm.TblFacilityImages = new TblFacilityImages();
            vm.TblFacility_List = context.TblFacilities.Include(x => x.Dep).ToList();
            vm.TblFacilityImages_List = context.TblFacilityImages.Include(x => x.TblFacility).Where(x=>x.FId == id).ToList(); //record ka Related Record Ayin gaa
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(VM_Facilities_images model)
        {
            //____________________ Single Table Record Update ___________
            #region old
            ////__ delete Image __
            //var folder = "";
            //if (model.BrowsImage != null)
            //{
            //    //______ 1st Delete Current Image _____
            //    if (model.ImageFacility != null)
            //    {
            //        var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.ImageFacility);
            //        if (System.IO.File.Exists(oldDirectory))
            //        {
            //            System.IO.File.Delete(oldDirectory);
            //        }
            //    }

            //    //______ 2nd Add new Image _______
            //    folder = "Images/Facilites/";
            //    folder += Guid.NewGuid().ToString() + "_" + model.BrowsImage.FileName;
            //    var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
            //    //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));

            //    using (var fileMode = new FileStream(serverFolder, FileMode.Create))
            //    {
            //        model.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
            //    }

            //    model.ImageFacility = folder;
            //}

            //context.TblFacilities.Update(model);
            //context.SaveChanges();
            //return RedirectToAction("Index");
            #endregion

            //____________________ Multiple Table Record Update ___________
            //__ delete Image __
            if (model.TblFacility.BrowsImage != null )
            {
                //_________ 1st Delete Main Images _____
                if (model.TblFacility.ImageFacility != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.TblFacility.ImageFacility);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }


                //_________ 3rd Add Main Image _______
                var folder = "Images/Facilites/";
                folder += Guid.NewGuid().ToString() + "_" + model.TblFacility.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.TblFacility.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                model.TblFacility.ImageFacility = folder;
            }

            //__ delete Multiple Image __
            if (model.Images != null)
            {
                //_________ 1 Delete Multiple Images _____
                var record = context.TblFacilityImages.Where(x => x.FId == model.TblFacility.FId);
                if (record.Count() > 0)
                {
                    
                    foreach (var item in record.ToList())
                    {
                        var serverFolder2 = Path.Combine(iWebHost.WebRootPath, item.ImageUrl);
                        if (System.IO.File.Exists(serverFolder2))
                        {
                            System.IO.File.Delete(serverFolder2);
                        }
                    }
                    context.TblFacilityImages.RemoveRange(record.ToList());

                }
                

                //_________ 2 Add Main Image _______
                foreach (var item in model.Images)
                {
                    string fileName = UploadFile(item); //file Image 1 by 1
                    var facilityMultipleImage = new TblFacilityImages
                    {
                        ImageUrl = fileName,
                        TblFacility = model.TblFacility, //facility ka Saraa Record
                        FId = model.TblFacility.FId
                    };

                    context.TblFacilityImages.Add(facilityMultipleImage); //file Image 1 by 1
                }
            }

            context.TblFacilities.Update(model.TblFacility);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion



        public IActionResult delete(int id)
        {
            //____________________________ Single Table Record Delete _______________________
            #region Old
            //var facility = context.TblFacilities.Find(id);

            ////______ Delete Main Image _____
            //var serverFolder = Path.Combine(iWebHost.WebRootPath, facility.ImageFacility);
            //if (System.IO.File.Exists(serverFolder))
            //{
            //    System.IO.File.Delete(serverFolder);
            //}

            //var selectedRecord = context.TblFacilities.Find(id);
            //context.TblFacilities.Remove(selectedRecord);
            //return View(selectedRecord);
            #endregion

            //____________________________ Multiple Record Delete _______________________
            VM_Facilities_images vm = new VM_Facilities_images();
            vm.TblFacility = context.TblFacilities.Include(x => x.TblFacilityImg).Where(x => x.FId == id).FirstOrDefault();//new TblFacilities();
            vm.TblFacilityImages = new TblFacilityImages();
            vm.TblFacility_List = context.TblFacilities.Include(x => x.Dep).ToList();
            vm.TblFacilityImages_List = context.TblFacilityImages.Include(x => x.TblFacility).Where(x => x.FId == id).ToList(); //record ka Related Record Ayin gaa

            //_______ 1. Delete Main Image _________
            var serverFolder1 = Path.Combine(iWebHost.WebRootPath, vm.TblFacility.ImageFacility);
            if (System.IO.File.Exists(serverFolder1))
            {
                System.IO.File.Delete(serverFolder1);
            }

            //_______ 2. Delete All Images of Selected Record _________
            foreach (var item in vm.TblFacilityImages_List.ToList())
            {
                var serverFolder2 = Path.Combine(iWebHost.WebRootPath, item.ImageUrl);
                if (System.IO.File.Exists(serverFolder2))
                {
                    System.IO.File.Delete(serverFolder2);
                }
            }

            

            context.TblFacilities.Remove(vm.TblFacility);
            context.TblFacilityImages.RemoveRange(vm.TblFacilityImages_List);
            context.SaveChanges();

            return RedirectToAction("Index");

            
        }


    }
}
