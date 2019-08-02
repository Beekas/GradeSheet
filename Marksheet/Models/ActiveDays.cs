using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class ActiveDays
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public string  TerminalName { get; set; }
        public int Activeday { get; set; }
        public int AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }

    }
}