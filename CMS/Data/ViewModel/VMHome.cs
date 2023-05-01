using CMS.Models;
using System.Collections.Generic;

namespace CMS.Data.ViewModel
{
    public class VMHome
    {
        //________________ List of Records _______________
        public IEnumerable<TblStudent> tblStudent_List { get; set; }
        public IEnumerable<TblSlider> tblSlider_List { get; set; }
        public IEnumerable<TblFaculties> TblTeacher_List { get; set; }

        public IEnumerable<TblCourse> Course_List { get; set; }

    }
}
