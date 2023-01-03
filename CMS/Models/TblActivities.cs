using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_activities")]
    public partial class TblActivities
    {
        [Key]
        [Column("act_id")]
        public int ActId { get; set; }
        [Column("stud_id")]
        public int? StudId { get; set; }
        [Column("assign_id")]
        public int? AssignId { get; set; }
        [Column("timetable_id")]
        public int? TimetableId { get; set; }

        [ForeignKey(nameof(AssignId))]
        [InverseProperty(nameof(TblAssignments.TblActivities))]
        public virtual TblAssignments Assign { get; set; }
        [ForeignKey(nameof(StudId))]
        [InverseProperty(nameof(TblStudent.TblActivities))]
        public virtual TblStudent Stud { get; set; }
        [ForeignKey(nameof(TimetableId))]
        [InverseProperty(nameof(TblTimetable.TblActivities))]
        public virtual TblTimetable Timetable { get; set; }
    }
}
