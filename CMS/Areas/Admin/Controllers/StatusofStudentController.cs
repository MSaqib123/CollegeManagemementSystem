using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatusofStudentController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public StatusofStudentController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblStatus.ToList();
            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblStatus model)
        {
            //___________ Create ___________
            context.TblStatus.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var selectedRecord = context.TblStatus.Find(id);
            return View(selectedRecord);
        }
        [HttpPost]
        public IActionResult Edit(TblStatus model)
        {
            context.TblStatus.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult delete(int id)
        {
            var Year = context.TblStatus.Find(id);


            context.TblStatus.Remove(Year);
            context.SaveChanges();
            TempData["error"] = "Removed Successfuly!";
            return RedirectToAction("Index");
        }

    }
}
