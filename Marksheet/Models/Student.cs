using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SymbolNo { get; set; }
        public string Sex { get; set; }
        public string Class { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Mobile { get; set; }
        public int SchoolId{ get; set; }
        public virtual School School { get; set; }
    }
}