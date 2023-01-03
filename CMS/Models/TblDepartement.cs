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
    [Table("tbl_departement")]
    public partial class TblDepartement
    {
        public TblDepartement()
        {
            TblCourse = new HashSet<TblCourse>();
            TblFacilities = new HashSet<TblFacilities>();
            TblFaculties = new HashSet<TblFaculties>();
        }

        [Key]
        [Column("dep_Id")]
        public int DepId { get; set; }
        [Column("departement")]
        [StringLength(25)]
        public string Departement { get; set; }
        [StringLength(100)]
        public string shortDescription{ get; set; }
        [StringLength(500)]
        public string longDescription { get; set; }
        [StringLength(250)]
        public string depImage { get; set; }

        [InverseProperty("Dep")]
        public virtual ICollection<TblCourse> TblCourse { get; set; }
        [InverseProperty("Dep")]
        public virtual ICollection<TblFacilities> TblFacilities { get; set; }
        [InverseProperty("Dep")]
        public virtual ICollection<TblFaculties> TblFaculties { get; set; }

        [NotMapped]
        public IFormFile BrowsImage { get; set; }

    }
}
