namespace Marksheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class marksheet : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Marksheets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SchoolId = c.Int(),
                        ResultStatus = c.Boolean(nullable: false),
                        AcedamicYearId = c.Int(nullable: false),
                        Term = c.String(),
                        Attendance = c.Int(nullable: false),
                        EnglishPM = c.Int(nullable: false),
                        EnglishTM = c.Int(nullable: false),
                        NepaliTM = c.Int(nullable: false),
                        NepaliPM = c.Int(nullable: false),
                        MathTM = c.Int(nullable: false),
                        SocialTM = c.Int(nullable: false),
                        SocialPM = c.Int(nullable: false),
                        HealthPM = c.Int(nullable: false),
                        HealthTM = c.Int(nullable: false),
                        SciencePM = c.Int(nullable: false),
                        ScienceTM = c.Int(nullable: false),
                        ObtePM = c.Int(nullable: false),
                        ObteTM = c.Int(nullable: false),
                        MoralTM = c.Int(nullable: false),
                        MoralPM = c.Int(nullable: false),
                        Optional1TM = c.Int(nullable: false),
                        Optional1PM = c.Int(nullable: false),
                        HasPractical1 = c.Boolean(nullable: false),
                        AcademicYear_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYear_Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AcademicYear_Id);
            
            
        }
        
        public override void Down()
        {
         
            DropIndex("dbo.Marksheets", new[] { "AcademicYear_Id" });
            DropIndex("dbo.Marksheets", new[] { "StudentId" });
            DropTable("dbo.Marksheets");
           
        }
    }
}
