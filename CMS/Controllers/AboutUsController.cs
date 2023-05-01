using CMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Controllers
{
    
    public class AboutUsController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public AboutUsController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }


        public IActionResult Index()
        {
            ViewBag.DepartmenetList = context.TblDepartement.ToList();

            var list = context.TblFaculties.Include(x => x.Dep).ToList();
            return View(list);
        }
    }
}
