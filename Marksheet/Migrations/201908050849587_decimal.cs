namespace Marksheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Marksheets", "EnglishPM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "EnglishTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "NepaliTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "NepaliPM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "MathTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "SocialTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "SocialPM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "HealthPM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "HealthTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "SciencePM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "ScienceTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "ObtePM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "ObteTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "MoralTM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "MoralPM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "Optional1TM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Marksheets", "Optional1PM", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Marksheets", "Optional1PM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "Optional1TM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "MoralPM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "MoralTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "ObteTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "ObtePM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "ScienceTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "SciencePM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "HealthTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "HealthPM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "SocialPM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "SocialTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "MathTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "NepaliPM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "NepaliTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "EnglishTM", c => c.Int(nullable: false));
            AlterColumn("dbo.Marksheets", "EnglishPM", c => c.Int(nullable: false));
        }
    }
}
