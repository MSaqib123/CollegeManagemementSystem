using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SpecializeSubjectController : Controller
    {

        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public SpecializeSubjectController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblSpecializesubject.ToList();
            return View(list);
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblSpecializesubject model)
        {
            //___________ Create ___________
            context.TblSpecializesubject.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            //var list1 = context.TblSubjects.ToList();
            //ViewBag.sbuj = new SelectList(list1, "SubId", "Subject");

            //var list2 = context.TblCourse.ToList();
            //ViewBag.course = new SelectList(list2, "CId", "Course");

            var selectedRecord = context.TblSpecializesubject.Find(id);
            return View(selectedRecord);
        }

        [HttpPost]
        public IActionResult Edit(TblSpecializesubject model)
        {
            context.TblSpecializesubject.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult delete(int id)
        {
            var selectedRecord = context.TblSpecializesubject.Find(id);

            context.TblSpecializesubject.Remove(selectedRecord);
            context.SaveChanges();
            return RedirectToAction("Index");
        }








    }
}
