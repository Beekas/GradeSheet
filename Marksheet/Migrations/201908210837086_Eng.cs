namespace Marksheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicYears", "ActiveYearEnglish", c => c.String());
            DropColumn("dbo.AcademicYears", "ActiveYearNepali");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AcademicYears", "ActiveYearNepali", c => c.String());
            DropColumn("dbo.AcademicYears", "ActiveYearEnglish");
        }
    }
}
