namespace Marksheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schoolcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schools", "SchoolCodeNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schools", "SchoolCodeNo");
        }
    }
}
