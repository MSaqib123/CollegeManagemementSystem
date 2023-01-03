using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    [Table("tbl_facilityImages")]
    public class TblFacilityImages
    {
        [Key]
        [Column("faci_img_id")]
        public int Id { get; set; }

        [Column("faci_Images")]
        public string ImageUrl { get; set; }


        //____ forign key ____
        [Column("facility_id")]
        public int? FId { get; set; }
        [ForeignKey(nameof(FId))]
        [InverseProperty(nameof(TblFacilities.TblFacilityImg))]
        public virtual TblFacilities TblFacility { get; set; }
    }
}
