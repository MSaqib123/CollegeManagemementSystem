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
    [Authorize(Roles = "Admin")]
    public class SubjectSSController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public SubjectSSController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblSubjects.Include(x=>x.Y).Include(x=>x.Course).Include(x=>x.SsCourse).ToList();
            return View(list);
        }


        public IActionResult Create()
        {
            var Course = context.TblCourse.ToList();
            ViewBag.Course = new SelectList(Course, "CId", "Course");

            var Y = context.TblYear.ToList();
            ViewBag.Year = new SelectList(Y, "YId", "Year");

            var SSList  = context.TblSpecializesubject.ToList();
            ViewBag.SSList = new SelectList(SSList, "SsId", "SsName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(TblSubjects model)
        {
            //___________ Create ___________
            context.TblSubjects.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var Course = context.TblCourse.ToList();
            ViewBag.Course = new SelectList(Course, "CId", "Course");

            var Y = context.TblYear.ToList();
            ViewBag.Year = new SelectList(Y, "YId", "Year");

            var SSList = context.TblSpecializesubject.ToList();
            ViewBag.SSList = new SelectList(SSList, "SsId", "SsName");


            var selectedRecord = context.TblSubjects.Include(x=>x.Y).Include(x=>x.Course).Include(x=>x.Y).Include(x=>x.SsCourse).AsNoTracking().Where(x=>x.SubId == id).FirstOrDefault();
            return View(selectedRecord);
        }

        [HttpPost]
        public IActionResult Edit(TblSubjects model)
        {
            context.TblSubjects.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult delete(int id)
        {
            var selectRecord = context.TblSubjects.Find(id);

            context.TblSubjects.Remove(selectRecord);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
