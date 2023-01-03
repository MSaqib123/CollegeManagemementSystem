
using CMS.Models;
using System.Collections;
using System.Collections.Generic;

namespace CMS.Data.ViewModel
{
    public class studnetEnrolmentViewModel
    {
        public TblStudent StudentTable { get; set; }
        public TblEnrolement EnrolmentTable { get; set; }

        public IEnumerable<TblEnrolement> enrolment_list { get; set; }

        public IEnumerable<TblSubjects> subject_sepecaliz_list{ get; set; }
        public IEnumerable<TblOptionalsubjects> subject_optional_list{ get; set; }
    }
}
