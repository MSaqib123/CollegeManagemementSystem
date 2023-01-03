using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_year")]
    public partial class TblYear
    {
        public TblYear()
        {
            TblSubjects = new HashSet<TblSubjects>();
            TblOSSubjects = new HashSet<TblOptionalsubjects>();
        }


        [Key]
        [Column("y_Id")]
        public int YId { get; set; }
        [Column("year")]
        [StringLength(25)]
        public string Year { get; set; }


        [InverseProperty("Y")]
        public virtual ICollection<TblSubjects> TblSubjects { get; set; }
        

        [InverseProperty("Y")]
        public virtual ICollection<TblOptionalsubjects> TblOSSubjects { get; set; }
    }
}
