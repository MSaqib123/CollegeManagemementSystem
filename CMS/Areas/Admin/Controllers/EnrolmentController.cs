using CMS.Data;
using CMS.Data.ViewModel;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EnrolmentController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;

        public EnrolmentController(cms_06GContext context, IWebHostEnvironment iWebHost)
        {
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            var enrolemrntList = context.TblEnrolement.Include(x=>x.Stu).Include(x => x.Specializesubject).Include(x => x.Optionalsubject).ToList();

            vmEnrolmentList stuEnrolment = new vmEnrolmentList();
            stuEnrolment.enrolment_list = enrolemrntList;
            stuEnrolment.subject_sepecaliz_list = context.TblSubjects.Include(x=>x.Course).ToList();
            stuEnrolment.subject_optional_list = context.TblOptionalsubjects.ToList();

            return View(stuEnrolment);
        }


        public IActionResult delete(int id)
        {
            var Course = context.TblCourse.Find(id);
            //______ 1st Delete Current Image _____
            if (Course.coImage != null)
            {
                var oldDirectory = Path.Combine(iWebHost.WebRootPath, Course.coImage);
                if (System.IO.File.Exists(oldDirectory))
                {
                    System.IO.File.Delete(oldDirectory);
                }
            }
            
            context.TblCourse.Remove(Course);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
