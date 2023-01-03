using CMS.Data;
using CMS.Data.ViewModel;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;
        private readonly UserManager<ApplicationUser> userManager;

        public StudentsController(IWebHostEnvironment iWebHost,cms_06GContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.iWebHost = iWebHost;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var list = context.TblStudent.Include(x => x.StuPreviousExeme).Include(x=>x.Status).Include(x=>x.Course).Include(x=>x.user).ToList();
            return View(list);
        }

        public IActionResult Edit(int id)
        {
            var list = context.TblStatus.ToList();
            ViewBag.status = new SelectList(list, "StaId", "Status");

            var studentRecord = context.TblStudent.Include(x => x.StuPreviousExeme).Include(x=>x.Course).AsNoTracking().FirstOrDefault(x => x.StuId == id);
            var enrolemrntRecord = context.TblEnrolement.Include(x => x.Specializesubject).Include(x => x.Optionalsubject).Where(x => x.StuId == id).FirstOrDefault();

            studnetEnrolmentViewModel stuEnrolment = new studnetEnrolmentViewModel();
            stuEnrolment.StudentTable = studentRecord;
            stuEnrolment.EnrolmentTable = context.TblEnrolement.Include(x => x.Specializesubject).Include(x => x.Optionalsubject).Where(x => x.StuId == id).FirstOrDefault();
            stuEnrolment.subject_sepecaliz_list = context.TblSubjects.ToList();
            stuEnrolment.subject_optional_list = context.TblOptionalsubjects.ToList();
            return View(stuEnrolment);
        }
        
        [HttpPost]
        public async Task<IActionResult>  Edit(studnetEnrolmentViewModel model)
        {
            ApplicationUser usr = await userManager.GetUserAsync(HttpContext.User);
            if (usr != null)
            {
                model.StudentTable.userId = usr.Id;
            }
            else
            {
                return RedirectToAction("SignIn", "Account", new { area = "Security" });
            }

            //__ delete Image __
            if (model.StudentTable.BrowsImage != null)
            {
                //_________ 1st Delete Main Images _____
                if (model.StudentTable.StuImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.StudentTable.StuImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }

                //_________ 3rd Add Main Image _______

                var folder = "Images/Facilites/";
                folder += Guid.NewGuid().ToString() + "_" + model.StudentTable.BrowsImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.BrowsImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.StudentTable.BrowsImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                model.StudentTable.StuImage = folder;
            }



            context.TblStudent.Update(model.StudentTable);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult delete(int id)
        {
            var students = context.TblStudent.Find(id);
            if (students.StuImage != null)
            {
                var oldDirectory = Path.Combine(iWebHost.WebRootPath, students.StuImage);
                if (System.IO.File.Exists(oldDirectory))
                {
                    System.IO.File.Delete(oldDirectory);
                }
            }
            context.TblStudent.Remove(students);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //_____ Course Detail Model _________
        public PartialViewResult _parExameTable()
        {
            //var list = dbContext.departements.ToList();   error
            ViewBag.list = context.TblStudent.Include(x => x.StuPreviousExeme).ToList();
            return PartialView("_parExameTable", ViewBag.list);
        }


        //_____ Course Detail Model _________
        public IActionResult parCourseTable()
        {
            return View();
        }

        





        //___________________ Create End mee kyun kaa ________________ (zydadaa tarrr student khud he registor hon gaa)
        //public IActionResult Create()
        //{
        //    var list = context.TblDepartement.ToList();
        //    ViewBag.dep = new SelectList(list, "DepId", "Departement");
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(TblCourse model)
        //{
        //    //___________ Create ___________
        //    context.TblCourse.Add(model);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }

}
