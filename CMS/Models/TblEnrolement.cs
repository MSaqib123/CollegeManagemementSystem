using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_enrolement")]
    public partial class TblEnrolement
    {
        [Key]
        [Column("enr_Id")]
        public int EnrId { get; set; }
        [Column("stu_id")]
        public int? StuId { get; set; }
        [Column("specializesubject_id")]
        public int? SpecializesubjectId { get; set; }
        [Column("optionalsubject_id")]
        public int? OptionalsubjectId { get; set; }

        [ForeignKey(nameof(OptionalsubjectId))]
        [InverseProperty(nameof(TblOptionalsubjects.TblEnrolement))]
        public virtual TblOptionalsubjects Optionalsubject { get; set; }
        [ForeignKey(nameof(SpecializesubjectId))]
        [InverseProperty(nameof(TblSpecializesubject.TblEnrolement))]
        public virtual TblSpecializesubject Specializesubject { get; set; }
        [ForeignKey(nameof(StuId))]
        [InverseProperty(nameof(TblStudent.TblEnrolement))]
        public virtual TblStudent Stu { get; set; }
    }
}
