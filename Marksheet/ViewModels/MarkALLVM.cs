using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.ViewModels
{
    public class MarkAllVM
    {
        public string Logo { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCodeNo { get; set; }
        public string AcademicYear { get; set; }
        public string Term { get; set; }
        public string StudentName { get; set; }
        public string SymbolNo { get; set; }
        public string DOB { get; set; }
        public decimal EnglishPM { get; set; }//PM-Practical Marks
        public decimal EnglishTM { get; set; }//TM-Therory Marks
        public decimal EnglishAM { get; set; }
        public decimal NepaliTM { get; set; }
        public decimal NepaliPM { get; set; }
        public decimal NepaliAM { get; set; }
        public decimal MathTM { get; set; }
        public decimal SocialTM { get; set; }
        public decimal SocialPM { get; set; }
        public decimal SocialAM { get; set; }
        public decimal HealthPM { get; set; }
        public decimal HealthTM { get; set; }
        public decimal HealthAM { get; set; }
        public decimal SciencePM { get; set; }
        public decimal ScienceTM { get; set; }
        public decimal ScienceAM { get; set; }
        public decimal ObtePM { get; set; }
        public decimal ObteTM { get; set; }
        public decimal ObteAM { get; set; }
        public decimal MoralTM { get; set; }
        public decimal MoralPM { get; set; }
        public decimal MoralAM { get; set; }
        public decimal Optional1TM { get; set; }
        public decimal Optional1PM { get; set; }
        public decimal Optional1AM { get; set; }
        public bool HasPractical1 { get; set; }
        public decimal GPA { get; set; }
        public string OptionalSubject { get; set; }
    }
}