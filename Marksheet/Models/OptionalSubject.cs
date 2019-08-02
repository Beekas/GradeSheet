using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class OptionalSubject
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public virtual School School { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

    }
}