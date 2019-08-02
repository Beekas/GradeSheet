using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubName { get; set; }
        public int TFullMarks { get; set; }
        public int? PFullMarks { get; set; }
        public int PPassMarks { get; set; }
        public int TPassMarks { get; set; }
        public bool Optional { get; set; }
        public bool HasPractical { get; set; }
    }
}