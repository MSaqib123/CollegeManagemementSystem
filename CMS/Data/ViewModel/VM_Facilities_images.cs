
using CMS.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CMS.Data.ViewModel
{
    public class VM_Facilities_images
    {
        //________________ Single Table _______________
        public TblFacilities TblFacility{ get; set; }
        public TblFacilityImages TblFacilityImages{ get; set; }

        //________________ List of Records _______________
        public IEnumerable<TblFacilities> TblFacility_List { get; set; }
        public IEnumerable<TblFacilityImages> TblFacilityImages_List { get; set; }


        //________________ Brows Multipe Images _______________
        public List<IFormFile> Images { get; set; }
    }
}
