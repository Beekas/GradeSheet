using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marksheet.ViewModels
{
    public class MarksheetVM
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int? SchoolId { get; set; }
        public string School { get; set; }
        public int AcedamicYearId { get; set; }
        public string AcademicYear { get; set; }
        public SelectList Terminal { get; set; }
        public SelectList AcademicYears { get; set; }
        public SelectList Schools { get; set; }
        public string Term { get; set; }
        public int Attendance { get; set; }

        public decimal EnglishPM { get; set; }//PM-Practical Marks
        public decimal EnglishTM { get; set; }//TM-Therory Marks
        public decimal NepaliTM { get; set; }
        public decimal NepaliPM { get; set; }
        public decimal MathTM { get; set; }
        public decimal SocialTM { get; set; }
        public decimal SocialPM { get; set; }
        public decimal HealthPM { get; set; }
        public decimal HealthTM { get; set; }
        public decimal SciencePM { get; set; }
        public decimal ScienceTM { get; set; }
        public string Optional1Name { get; set; }
        public bool Opt1HasPractical { get; set; }
        public decimal Optional1PM { get; set; }
        public decimal Optional1TM { get; set; }
        public decimal ObtePM { get; set; }
        public decimal ObteTM { get; set; }
        public decimal MoralTM { get; set; }
        public decimal MoralPM { get; set; }
    }
}