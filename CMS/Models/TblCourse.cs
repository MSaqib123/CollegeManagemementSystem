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
    [Table("tbl_Course")]
    public partial class TblCourse
    {
        public TblCourse()
        {
            TblStudent = new HashSet<TblStudent>();
            tblSubjects = new HashSet<TblSubjects>();
        }


        [Key]
        [Column("c_Id")]
        public int CId { get; set; }


        [Column("course")]
        [StringLength(25)]
        public string Course { get; set; }


        [Column("description")]
        [StringLength(250)]
        public string courseDesc{ get; set; }


        [Column("c_createdate", TypeName = "date")]
        public DateTime? CCreatedate { get; set; }

        [StringLength(250)]
        public string? coImage { get; set; }


        [Column("dep_id")]
        public int? DepId { get; set; }


        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(TblDepartement.TblCourse))]
        public virtual TblDepartement Dep { get; set; }


        [InverseProperty("Course")]
        public virtual ICollection<TblStudent> TblStudent { get; set; }


        [InverseProperty("Course")]
        public virtual ICollection<TblSubjects> tblSubjects { get; set; }


        [NotMapped]
        public IFormFile BrowsImage { get; set; }


    }
}
