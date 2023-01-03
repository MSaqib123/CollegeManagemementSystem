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
    [Table("tbl_facilities")]
    public partial class TblFacilities
    {
        public TblFacilities()
        {
            TblFacilityImg = new HashSet<TblFacilityImages>();
        }

        [Key]
        [Column("f_id")]
        public int FId { get; set; }

        [Column("facility")]
        [StringLength(25)]
        public string Facility { get; set; }

        [Column("dep_id")]
        public int? DepId { get; set; }

        [Column("image_facility")]
        [StringLength(250)]
        public string ImageFacility { get; set; }

        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }

        [ForeignKey(nameof(DepId))]
        [InverseProperty(nameof(TblDepartement.TblFacilities))]
        public virtual TblDepartement Dep { get; set; }


        [InverseProperty("TblFacility")]
        public virtual ICollection<TblFacilityImages> TblFacilityImg { get; set; }



        [NotMapped]
        public IFormFile BrowsImage { get; set; }

    }
}
