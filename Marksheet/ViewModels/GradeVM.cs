using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.ViewModels
{
    public class GradeVM
    {
        public string StudentName { get; set; }
        public string DOB { get; set; }
        public string DOBNep { get; set; }
        public string RollNo { get; set; }
        public string TerminalExam { get; set; }
        public string AcademicYear { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string StudentAddress { get; set; }
        public string StudentClass { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string AcademicDay { get; set; }
        public string PresentDay { get; set; }
        public string Logo { get; set; }
        public string SchoolCodeNo { get; set; }

        public List<SubjectVM> Subjects { get; set; }


        public string GPA { get; set; }
        public string AggregateGPA { get; set; }

        
    }

        public class SubjectVM {
        public string SerialNo { get; set; }
        public string SubjectName { get; set; }
        public string CreditHour{ get; set; }
        public string Theory { get; set; }
        public string Practical { get; set; }
        public string FinalGrade { get; set; }
        public string GradePoint { get; set; }
        public string Remarks { get; set; }
        public int Serial { get; set; }
    }


}