namespace Marksheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resultDateActiveYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicYears", "ResultDate", c => c.String());
            AddColumn("dbo.AcademicYears", "ActiveYearNepali", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicYears", "ActiveYearNepali");
            DropColumn("dbo.AcademicYears", "ResultDate");
        }
    }
}
