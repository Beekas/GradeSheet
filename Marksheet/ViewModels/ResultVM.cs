using Marksheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.ViewModels
{
    public class ResultVM
    {
        public Student Student { get; set; }
        public Models.Marksheet Marksheet { get; set; }
        public string GPA { get; set; }
        public string GradePoint { get; set; }
    }
}