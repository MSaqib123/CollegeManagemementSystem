using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CMS.Models
{
    [Table("tbl_status")]
    public partial class TblStatus
    {
        public TblStatus()
        {
            TblStudent = new HashSet<TblStudent>();
        }

        [Key]
        [Column("sta_Id")]
        public int StaId { get; set; }
        [Column("status")]
        [StringLength(25)]
        public string Status { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<TblStudent> TblStudent { get; set; }
    }
}
