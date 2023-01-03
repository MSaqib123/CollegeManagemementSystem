using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_previouseExameDetails")]
    public partial class TblPreviouseExameDetails
    {
        public TblPreviouseExameDetails()
        {
            tblStudent = new HashSet<TblStudent>();
        }

        [Key]
        [Column("pre_Id")]
        public int PreId { get; set; }
        [Column("university")]
        [StringLength(30)]
        public string University { get; set; }
        [Column("enrolmentNo")]
        [StringLength(15)]
        public string EnrolmentNo { get; set; }
        [Column("center")]
        [StringLength(50)]
        public string Center { get; set; }
        [Column("stream")]
        [StringLength(50)]
        public string Stream { get; set; }
        [Column("field")]
        [StringLength(50)]
        public string Field { get; set; }
        [Column("marks_secured")]
        [StringLength(10)]
        public string MarksSecured { get; set; }
        [Column("out_of_marks")]
        [StringLength(10)]
        public string OutOfMarks { get; set; }
        [Column("class_obtained")]
        [StringLength(10)]
        public string ClassObtained { get; set; }


        public int? StId { get; set; }
        [ForeignKey(nameof(StId))]
        [InverseProperty(nameof(TblStudent.prevExame))]
        public virtual TblStudent students{ get; set; }


        [InverseProperty("StuPreviousExeme")]
        public virtual ICollection<TblStudent> tblStudent { get; set; }
    }
}
