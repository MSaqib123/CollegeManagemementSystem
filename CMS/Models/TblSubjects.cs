using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_subjects")]
    public partial class TblSubjects
    {
        public TblSubjects()
        {
        }

        [Key]
        [Column("sub_id")]

        public int SubId { get; set; }


        [Column("subject")]
        public string Subject { get; set; }


        [Column("c_id")]
        public int? Course_id { get; set; }



        [Column("y_id")]
        public int? YId { get; set; }



        [Column("ss_id")]
        public int? SS_id { get; set; }




        [ForeignKey(nameof(SS_id))]
        [InverseProperty(nameof(TblSpecializesubject.tblSubjects))]
        public virtual TblSpecializesubject SsCourse { get; set; }



        [ForeignKey(nameof(YId))]
        [InverseProperty(nameof(TblYear.TblSubjects))]
        public virtual TblYear Y { get; set; }



        [ForeignKey(nameof(Course_id))]
        [InverseProperty(nameof(TblCourse.tblSubjects))]
        public virtual TblCourse Course { get; set; }



    }
}
