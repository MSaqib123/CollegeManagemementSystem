using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_timetable")]
    public partial class TblTimetable
    {
        public TblTimetable()
        {
            TblActivities = new HashSet<TblActivities>();
        }

        [Key]
        [Column("tt_Id")]
        public int TtId { get; set; }
        [Column("tt_name")]
        [StringLength(50)]
        public string TtName { get; set; }

        [InverseProperty("Timetable")]
        public virtual ICollection<TblActivities> TblActivities { get; set; }
    }
}
