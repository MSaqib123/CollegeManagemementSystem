using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_assignments")]
    public partial class TblAssignments
    {
        public TblAssignments()
        {
            TblActivities = new HashSet<TblActivities>();
        }

        [Key]
        [Column("assi_Id")]
        public int AssiId { get; set; }
        [Column("assi_name")]
        [StringLength(25)]
        public string AssiName { get; set; }
        [Column("assi_description")]
        [StringLength(150)]
        public string AssiDescription { get; set; }
        [Column("assi_startdate", TypeName = "date")]
        public DateTime? AssiStartdate { get; set; }
        [Column("assi_enddate", TypeName = "date")]
        public DateTime? AssiEnddate { get; set; }

        [InverseProperty("Assign")]
        public virtual ICollection<TblActivities> TblActivities { get; set; }
    }
}
