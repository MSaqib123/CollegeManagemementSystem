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
    public class OptionalSubjectController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public OptionalSubjectController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }


        public IActionResult Index()
        {
            var list = context.TblOptionalsubjects.Include(x=>x.Y).ToList();
            return View(list);
        }



        public IActionResult Create()
        {
            var Y = context.TblYear.ToList();
            ViewBag.Year = new SelectList(Y, "YId", "Year");

            return View();
        }
        [HttpPost]
        public IActionResult Create(TblOptionalsubjects model)
        {
            //___________ Create ___________
            context.TblOptionalsubjects.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var Y = context.TblYear.ToList();
            ViewBag.Year = new SelectList(Y, "YId", "Year");

            var selectedRecord = context.TblOptionalsubjects.Find(id);
            return View(selectedRecord);
        }
        
        [HttpPost]
        public IActionResult Edit(TblOptionalsubjects model)
        {
            context.TblOptionalsubjects.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult delete(int id)
        {
            var selectedRecord = context.TblOptionalsubjects.Find(id);


            context.TblOptionalsubjects.Remove(selectedRecord);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
