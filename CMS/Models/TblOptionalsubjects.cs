using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_optionalsubjects")]
    public partial class TblOptionalsubjects
    {
        public TblOptionalsubjects()
        {
            TblEnrolement = new HashSet<TblEnrolement>();
        }

        [Key]
        [Column("os_id")]
        public int OsId { get; set; }
        [Column("optinalSubject")]
        [StringLength(25)]
        public string OptinalSubject { get; set; }


        [Column("y_id")]
        public int? YId { get; set; }


        [ForeignKey(nameof(YId))]
        [InverseProperty(nameof(TblYear.TblOSSubjects))]
        public virtual TblYear Y { get; set; }


        [InverseProperty("Optionalsubject")]
        public virtual ICollection<TblEnrolement> TblEnrolement { get; set; }
    }
}
