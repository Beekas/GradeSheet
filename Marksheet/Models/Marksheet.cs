using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class Marksheet
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? SchoolId { get; set; }
        public bool ResultStatus { get; set; }
        public int AcedamicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
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
        public decimal ObtePM { get; set; }
        public decimal ObteTM { get; set; }
        public decimal MoralTM { get; set; }
        public decimal MoralPM { get; set; }
        public decimal Optional1TM { get; set; }
        public decimal Optional1PM { get; set; }
        public bool HasPractical1 { get; set; }
    }
}