using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_student_teacher")]
    public partial class TblStudentTeacher
    {
        [Key]
        [Column("s_t_id")]
        public int STId { get; set; }
        [Column("student_id")]
        public int? StudentId { get; set; }
        [Column("faculity_id")]
        public int? FaculityId { get; set; }

        [ForeignKey(nameof(FaculityId))]
        [InverseProperty(nameof(TblFaculties.TblStudentTeacher))]
        public virtual TblFaculties Faculity { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(TblStudent.TblStudentTeacher))]
        public virtual TblStudent Student { get; set; }
    }
}
