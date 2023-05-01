using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class TblSlider
    {

        [Key]
        [Column("Slider_Id")]
        public int SId { get; set; }


        [Column("Title")]
        [StringLength(50)]
        public string Title { get; set; }


        [Column("SubTitle")]
        [StringLength(50)]
        public string SubTitle { get; set; }


        [Column("slider_detail")]
        [StringLength(250)]
        public string details { get; set; }


        [StringLength(300)]
        public string? sliderImage { get; set; }


        [NotMapped]
        public IFormFile BrowsImage { get; set; }
    }
}
