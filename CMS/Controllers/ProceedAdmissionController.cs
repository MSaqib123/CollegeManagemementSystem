using CMS.Data;
using CMS.Data.ViewModel;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class ProceedAdmissionController : Controller
    {
        private readonly cms_06GContext context;
        private readonly IWebHostEnvironment iWebHost;
        private readonly UserManager<ApplicationUser> userManager;
        public ProceedAdmissionController(cms_06GContext context, IWebHostEnvironment iWebHost, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.context = context;
            this.iWebHost = iWebHost;
        }

        public IActionResult Index()
        {
            //TblStudent stud = new TblStudent();
            //return View(stud);
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index(int? studentId )
        {
            ApplicationUser usr = await userManager.GetUserAsync(HttpContext.User);
            if (usr != null)
            {
                var findStudent = context.TblStudent.Where(x => x.StuId == studentId).FirstOrDefault();
                if (studentId != 0 && findStudent != null)
                {
                    //if (findStudent != null)
                    if (findStudent.userId == usr.Id && findStudent.StuId == studentId)
                    {
                        if ((findStudent.StatusId >= 1 && findStudent.StatusId <= 2)) //panding , accepted
                        {
                            var state = context.TblStatus.Where(x => x.StaId == findStudent.StatusId).FirstOrDefault().Status;
                            if (findStudent.StatusId == 1)
                            {
                                TempData["error"] = "Please Wait : " + state;
                            }
                            else if (findStudent.StatusId == 2)
                            {
                                TempData["info"] = "Procced More : " + state;
                            }
                            
                            return View(findStudent);
                        }
                        else if ((findStudent.StatusId == 4)) //4. rejected
                        {
                            //TempData["error"] = "Rejected Admission ...";
                            TempData["swalerror"] = "Your Form is Rejected...";
                            TempData["swalText"] = "Visit Office board";
                            return View(findStudent);
                        }
                        else //3 registed 
                        {
                            //TempData["success"] = "You succeseded to Registored check Your Portal...";
                            TempData["swalsuccess"] = "Admission Is Completed...";
                            TempData["swalText"] = "Check Your Protal";
                            return View();
                        }
                    }
                    else
                    {
                        //TempData["error"] = "Its Not Your Id";
                        TempData["error"] = "Please Create Registration Form";
                        return View();
                    }
                }
                else
                {
                    TempData["error"] = "Enter StudentId...";
                    //ViewBag.NotFound = "Empty Student_id";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("SignIn", "Account", new { area = "Security" });
            }
            return View(studentId);

        }


        [Authorize]
        public IActionResult Update(int id)
        {
            //1. Course
            var CourseList = context.TblCourse.ToList();
            ViewBag.Course = new SelectList(CourseList, "CId", "Course");

            //2. Year
            var YearsList = context.TblYear.ToList();
            ViewBag.Years = new SelectList(YearsList, "YId", "Year");


            //4. Subject
            //var optionalsubject = context.TblOptionalsubjects.ToList();
            //ViewBag.OptinalSubjects = new SelectList(optionalsubject, "OsId", "OptinalSubject");

            studnetEnrolmentViewModel stuEnrolment = new studnetEnrolmentViewModel();
            stuEnrolment.StudentTable = context.TblStudent.Include(x => x.StuPreviousExeme).Where(x => x.StuId == id).FirstOrDefault();
            stuEnrolment.EnrolmentTable = new TblEnrolement();

            return View(stuEnrolment);
        }
        [HttpPost]
        public async Task<IActionResult> Update(studnetEnrolmentViewModel model)
        {
            //1. Course
            var CourseList = context.TblCourse.ToList();
            ViewBag.Course = new SelectList(CourseList, "CId", "Course");

            //2. Year
            var YearsList = context.TblYear.ToList();
            ViewBag.Years = new SelectList(YearsList, "YId", "Year");

            //___ validation ____ end me
            if (model.StudentTable.CourseId != 0 && model.EnrolmentTable.Optionalsubject.YId != 0)
            {
                //_______________ tbl_Student __________________
                model.StudentTable.StatusId = 3;  //1_pending , 2_completed  ,  3_successed

                ApplicationUser usr = await userManager.GetUserAsync(HttpContext.User);
                model.StudentTable.userId = usr.Id;
                context.TblStudent.Update(model.StudentTable);


                //_______________ tbl_Enrolment __________________
                var specializeTblId = context.TblSubjects.Where(x => x.Course_id == model.StudentTable.CourseId && x.YId == model.EnrolmentTable.Optionalsubject.YId).FirstOrDefault();

                model.EnrolmentTable.StuId = model.StudentTable.StuId;
                model.EnrolmentTable.SpecializesubjectId = specializeTblId.SS_id;
                model.EnrolmentTable.OptionalsubjectId = specializeTblId.YId;  //year Id saa ---> hum     Optional subject get kr lain gaa

                context.TblEnrolement.Add(model.EnrolmentTable);
                context.SaveChanges();

                TempData["swalsuccess"] = "Admission Is Completed...";
                TempData["swalText"] = "Check Your Protal";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Select Subjects";
                return View(model);
            }
            
        }






        ////___________________________ 1. Ajax __ SSSubject , OSSubjectet Loadd____________________________

        [Authorize]
        public IActionResult SetSubjects()
        {
            IEnumerable<TblSubjects> subCats = context.TblSubjects.ToList();
            ViewBag.SpecializeSubject = new SelectList(subCats, "SubId", "Subject");
            return PartialView("_Subjects", ViewBag.SpecializeSubject);
        }
        [Authorize]
        public IActionResult SetOPSubjects()
        {
            IEnumerable<TblOptionalsubjects> subCats = context.TblOptionalsubjects.ToList();
            ViewBag.OptinalSubjects = new SelectList(subCats, "OsId", "OptinalSubject");

            return PartialView("_Subjects2", ViewBag.OptinalSubjects);
        }

        [Authorize]
        //___________________________ 2. Ajax __ Selected SS_Subjectet By Course _________________________
        public IActionResult SetCoursePost(int selectedCourseId)
        {
            List<TblSubjects> subCats = context.TblSubjects.ToList();

            if (selectedCourseId > 0)
            {
                subCats = context.TblSubjects.Where(x => x.Course.CId == selectedCourseId).ToList();
            }

            ViewBag.SpecializeSubject = new SelectList(subCats, "SubId", "Subject");
            return PartialView("_Subjects", ViewBag.SpecializeSubject);
        }
        [Authorize]
        public IActionResult SetSubjectsPost(int selectedYearId, int selectedCourseId)
        {
            List<TblSubjects> subCats = context.TblSubjects.ToList();

            if (selectedCourseId > 0)
            {
                subCats = context.TblSubjects.Where(x => x.Course.CId == selectedCourseId && x.YId == selectedYearId).ToList();
            }

            ViewBag.SpecializeSubject = new SelectList(subCats, "SubId", "Subject");
            return PartialView("_Subjects", ViewBag.SpecializeSubject);
        }



        //___________________________ 3. Ajax __ Selected OP_Subjectet By Course _________________________
        [Authorize]
        public IActionResult SetYearPost_SSsubject(int selectedYearId)
        {
            List<TblOptionalsubjects> subCats = context.TblOptionalsubjects.ToList();

            if (selectedYearId > 0)
            {
                subCats = context.TblOptionalsubjects.Where(x => x.YId == selectedYearId).ToList();
            }

            ViewBag.OptinalSubjects = new SelectList(subCats, "OsId", "OptinalSubject");
            return PartialView("_Subjects2", ViewBag.OptinalSubjects);
        }



    }
}
