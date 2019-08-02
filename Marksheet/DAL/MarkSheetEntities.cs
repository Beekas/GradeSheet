using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Marksheet.Models;

namespace Marksheet.DAL
{
    public class MarkSheetEntities : DbContext
        {
            public MarkSheetEntities()
                : base("DefaultConnection")
            {
            }
           

        public DbSet<Student> Students{ get; set; }
        public DbSet<School> Schools{ get; set; }
        public DbSet<AcademicYear> AcademicYears{ get; set; }
        public DbSet<ActiveDays> ActiveDays{ get; set; }
        public DbSet<Models.Marksheet> Marksheets{ get; set; }
        public DbSet<Subject> Subjects{ get; set; }
        public DbSet<OptionalSubject> OptionalSubjects{ get; set; }

        public DbSet<Account> Accounts { get; set; }

    }
}