using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.ViewModels
{
    public class ActiveDaysVM
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public string TerminalName { get; set; }
        public int Activedays { get; set; }
        public int AcademicYearId { get; set; }
    }
}