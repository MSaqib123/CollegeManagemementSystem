using CMS.Models;
using System.Collections.Generic;

namespace CMS.Data.ViewModel
{
    public class vmEnrolmentList
    {
        public IEnumerable<TblEnrolement> enrolment_list { get; set; }

        public IEnumerable<TblSubjects> subject_sepecaliz_list { get; set; }
        public IEnumerable<TblOptionalsubjects> subject_optional_list { get; set; }
    }
}
