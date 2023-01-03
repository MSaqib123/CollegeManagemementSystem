using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_student")]
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblActivities = new HashSet<TblActivities>();
            TblEnrolement = new HashSet<TblEnrolement>();
            TblStudentTeacher = new HashSet<TblStudentTeacher>();
        }

        [Key]
        [Column("stu_Id")]
        public int StuId { get; set; }
        [Column("stu_name")]
        [StringLength(30)]
        [Required]
        public string StuName { get; set; }
        [Column("stu_fathername")]
        [StringLength(30)]
        [Required]
        public string StuFathername { get; set; }
        [Column("stu_mothername")]
        [StringLength(30)]
        public string StuMothername { get; set; }
        [Column("stu_image")]
        [StringLength(250)]
        public string StuImage { get; set; }
        [Column("stu_dateofBirth", TypeName = "date")]
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StuDateofBirth { get; set; }
        [Column("stu_parementaddress")]
        [StringLength(50)]
        public string StuParementaddress { get; set; }
        [Column("stu_residentialaddress")]
        [StringLength(50)]
        public string StuResidentialaddress { get; set; }
        [Column("course_id")]
        public int? CourseId { get; set; }
        [Column("stu_previousExeme_Id")]
        public int? StuPreviousExemeId { get; set; }
        [Column("status_id")]
        public int? StatusId { get; set; } = 1; //default  Pending Statuss

        
        [Column("userId")]
        public string? userId { get; set; } //default  Pending Statuss
        [ForeignKey(nameof(userId))]
        [InverseProperty(nameof(ApplicationUser.Student))]
        public virtual ApplicationUser user{ get; set; }

        
        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(TblCourse.TblStudent))]
        public virtual TblCourse Course { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(TblStatus.TblStudent))]
        public virtual TblStatus Status { get; set; }
        [ForeignKey(nameof(StuPreviousExemeId))]
        [InverseProperty(nameof(TblPreviouseExameDetails.tblStudent))]
        public virtual TblPreviouseExameDetails StuPreviousExeme { get; set; }

        [InverseProperty("Stud")]
        public virtual ICollection<TblActivities> TblActivities { get; set; }
        [InverseProperty("Stu")]
        public virtual ICollection<TblEnrolement> TblEnrolement { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<TblStudentTeacher> TblStudentTeacher { get; set; }


        [InverseProperty("students")]
        public virtual ICollection<TblPreviouseExameDetails> prevExame{ get; set; }

        [NotMapped]
        public IFormFile BrowsImage { get; set; }
        
    }
}
