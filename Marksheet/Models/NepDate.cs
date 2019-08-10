using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marksheet.Models
{
    public class NepDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string WeekDayName { get; set; }
        public string MonthName { get; set; }
        public int WeekDay { get; set; }
    }
}