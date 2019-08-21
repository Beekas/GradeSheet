using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public string FiscalYear { get; set; }
        public string Year { get; set; }
        public bool ActiveYear { get; set; }
        public string ResultDate { get; set; }
        public string ActiveYearEnglish { get; set; }
    }
}