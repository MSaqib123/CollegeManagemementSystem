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
    [Table("tbl_faculties")]
    public partial class TblFaculties
    {
        public TblFaculties()
        {
            TblStudentTeacher = new HashSet<TblStudentTeacher>();
        }

        [Key]
        [Column("f_id")]
        public int FId { get; set; }
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }
        [Column("dateofBirth", TypeName = "date")]
        public DateTime? DateofBirth { get; set; }
        [Column("ageby_dob", TypeName = "date")]
        public DateTime? AgebyDob { get; set; }
        [Column("fac_image")]
        [StringLength(250)]
        public string FacImage { get; set; }
        [Column("dep_id")]
        public int? DepId { get; set; }

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(TblDepartement.TblFaculties))]
        public virtual TblDepartement Dep { get; set; }
        [InverseProperty("Faculity")]
        public virtual ICollection<TblStudentTeacher> TblStudentTeacher { get; set; }



        [NotMapped]
        public  IFormFile BrowsImage { get; set; }

    }
}
