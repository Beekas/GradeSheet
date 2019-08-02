using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.ViewModels
{
    public class MarksVM
    {
        public string StudentName { get; set; }
        public string DOB { get; set; }
        public string RollNo { get; set; }
        public string TerminalExam { get; set; }
        public string AcademicYear { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string StudentClass { get; set; }
        public string StudentAddress { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string AcademicDay { get; set; }
        public string PresentDay { get; set; }

        public List<SubjectMarkVM> Subjects { get; set; }


        public string GrandTotal { get; set; }
        public string Percentage { get; set; }
        public string Division { get; set; }
    }

    public class SubjectMarkVM
    {
        public string SerialNo { get; set; }
        public string SubjectName { get; set; }
        public string FullMarks { get; set; }
        public string PassMarks { get; set; }
        public string Theory { get; set; }
        public string Practical { get; set; }
        public string Total { get; set; }
        public string Remarks { get; set; }


    }

}