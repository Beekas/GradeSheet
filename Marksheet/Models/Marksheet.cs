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

        public int EnglishPM { get; set; }//PM-Practical Marks
        public int EnglishTM { get; set; }//TM-Therory Marks
        public int NepaliTM { get; set; }
        public int NepaliPM { get; set; }
        public int MathTM { get; set; }
        public int SocialTM { get; set; }
        public int SocialPM { get; set; }
        public int HealthPM { get; set; }
        public int HealthTM { get; set; }
        public int SciencePM { get; set; }
        public int ScienceTM { get; set; }
        public int ObtePM { get; set; }
        public int ObteTM { get; set; }
        public int MoralTM { get; set; }
        public int MoralPM { get; set; }
        public int Optional1TM { get; set; }
        public int Optional1PM { get; set; }
        public bool HasPractical1 { get; set; }
    }
}