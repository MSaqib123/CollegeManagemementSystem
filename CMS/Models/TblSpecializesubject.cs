using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_specializesubject")]
    public partial class TblSpecializesubject
    {
        public TblSpecializesubject()
        {
            TblEnrolement = new HashSet<TblEnrolement>();
            tblSubjects = new HashSet<TblSubjects>();
        }

        [Key]
        
        [Column("ss_Id")]
        public int SsId { get; set; }

        [Column("ss_Name")]
        public string SsName { get; set; }


        [InverseProperty("Specializesubject")]
        public virtual ICollection<TblEnrolement> TblEnrolement { get; set; }


        [InverseProperty("SsCourse")]
        public virtual ICollection<TblSubjects> tblSubjects { get; set; }
    }
}
