using CMS.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class YearsController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public YearsController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var list = context.TblYear.ToList();
            return View(list);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TblYear model)
        {
            //___________ Create ___________
            context.TblYear.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int id)
        {
            var selectedRecord = context.TblYear.Find(id);
            return View(selectedRecord);
        }
        [HttpPost]
        public IActionResult Edit(TblYear model)
        {
            context.TblYear.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult delete(int id)
        {
            var Year = context.TblYear.Find(id);


            context.TblYear.Remove(Year);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
