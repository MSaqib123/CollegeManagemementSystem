using CMS.Data;
using CMS.Data.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {

        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public HomeController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }


        public IActionResult Index()
        {
            VMHome vm = new VMHome();
            vm.tblSlider_List = context.TblSlider.ToList();
            vm.Course_List = context.TblCourse.Include(x=>x.Dep).ToList();
            vm.TblTeacher_List = context.TblFaculties.Include(x=>x.Dep).ToList();
            vm.tblStudent_List = context.TblStudent.Include(x=>x.Course).ToList();
            return View(vm);
        }

        public IActionResult pageNotFound()
        {
            return View();
        }


    }
}
