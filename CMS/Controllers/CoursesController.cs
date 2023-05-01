using CMS.Data;
using CMS.Data.ViewModel;
using CMS.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Controllers
{
    public class CoursesController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;
        private readonly UserManager<ApplicationUser> userManager;
        public CoursesController(cms_06GContext context, IWebHostEnvironment iWebHost, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            //var list = context.TblCourse.Include(x=>x.TblStudent).ToList();
            //return View(list);
            VMHome vm = new VMHome();
            vm.Course_List = context.TblCourse.Include(x => x.Dep).ToList();
            vm.TblTeacher_List = context.TblFaculties.Include(x => x.Dep).ToList();
            vm.tblStudent_List = context.TblStudent.Include(x=>x.Course).ToList();
            return View(vm);
        }

    }
}
