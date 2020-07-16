namespace ProjectITP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToExamModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Date", c => c.String(nullable: false));
            AlterColumn("dbo.Exams", "Time", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "Time", c => c.String());
            AlterColumn("dbo.Exams", "Date", c => c.String());
            AlterColumn("dbo.Exams", "Location", c => c.String());
        }
    }
}
